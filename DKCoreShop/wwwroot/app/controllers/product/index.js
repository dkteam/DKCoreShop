var productController = function () {
    this.initialize = function () {
        loadData();
    }

    function registerEvents() {
        //TODO: binding events to controls
    }

    function loadData() {
        var template = $('#table-template').html();
        var renderData = '';
        $.ajax({
            type: 'GET',
            url: '/admin/product/GetAll',
            dataType: 'json',
            success: function (response) {
                $.each(response, function (i, item) {
                    renderData += Mustache.render(template, {
                        Image: item.Image == null ? '<img src = "/admin-site/images/user.png" width=25' : '<img src ="' + item.Image + '" width=25>',
                        Name: item.Name,
                        Price: dkteam.formatNumber(item.Price,0),
                        CategoryName: item.ProductCategory.Name,
                        CreatedDate: dkteam.dateTimeFormatJson(item.DateCreated),
                        Status: dkteam.getStatus(item.Status)
                    });
                    if (renderData != '') {
                        $('#tbl-ProductList').html(renderData);
                    }
                });
            },
            error: function (status) {
                console.log(status);
                //dkteam.notify('Cannot get data', 'error');
            }
        })
    }
}