var productController = function () {
    this.initialize = function () {
        loadData();
        registerEvents();
    }

    function registerEvents() {
        //TODO: binding events to controls
        $('#ddlShowPage').on('change', function () {
            dkteam.configs.pageSize = $(this).val();
            dkteam.configs.pageIndex = 1;
            loadData(true);
        });
    }

    function loadData(isPageChanged) {
        var template = $('#table-template').html();
        var renderData = '';
        $.ajax({
            type: 'GET',
            data: {
                categoryId: null,
                keyword: $('#txtKeyword').val(),
                page: dkteam.configs.pageIndex,
                pageSize: dkteam.configs.pageSize
            },
            url: '/admin/product/GetAllPaging',
            dataType: 'json',
            success: function (response) {
                console.log(response);
                $.each(response.Results, function (i, item) {
                    renderData += Mustache.render(template, {
                        Image: item.Image == null ? '<img src = "/admin-site/images/user.png" width=25' : '<img src ="' + item.Image + '" width=25>',
                        Name: item.Name,
                        Price: dkteam.formatNumber(item.Price, 0),
                        CategoryName: item.ProductCategory.Name,
                        CreatedDate: dkteam.dateTimeFormatJson(item.DateCreated),
                        Status: dkteam.getStatus(item.Status)
                    });
                    $('#lblTotalRecords').text(response.RowCount);
                    if (renderData != '') {
                        $('#tbl-ProductList').html(renderData);
                    }
                    wrapPaging(response.RowCount, function () {
                        loadData();
                    }, isPageChanged)
                });
            },
            error: function (status) {
                console.log(status);
                //dkteam.notify('Cannot get data', 'error');
            }
        });
    }

    function wrapPaging(recordCount, callBack, changePageSize) {
        var totalsize = Math.ceil(recordCount / dkteam.configs.pageSize);
        //Unbind pagination if it existed or click change pagesize
        if ($('#paginationUL a').length === 0 || changePageSize === true) {
            $('#paginationUL').empty();
            $('#paginationUL').removeData("twbs-pagination");
            $('#paginationUL').unbind("page");
        }
        //Bind Pagination Event
        $('#paginationUL').twbsPagination({
            totalPages: totalsize,
            visiblePages: 7,
            first: 'Đầu',
            prev: 'Trước',
            next: 'Tiếp',
            last: 'Cuối',
            onPageClick: function (event, p) {
                dkteam.configs.pageIndex = p;
                setTimeout(callBack(), 200);
            }
        });
    }
}