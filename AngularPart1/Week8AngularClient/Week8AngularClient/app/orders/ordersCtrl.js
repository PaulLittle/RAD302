(function () {
    "use strict";
    angular
    .module("orderManagement")
    .controller("OrderCtrl",
    ["orderResource",
        OrderCtrl]);

    function OrderCtrl(orderResource) {
        var vm = this;
        vm.Lines = [];
        orderResource.Orders.query(function (data) {
            vm.orders = data;
        });

        vm.getOrderWithProducts = function (OrderId) {
            orderResource.OrdersWithProducts.query({ id: OrderId },
                function (data) {
                    vm.productOrderLines = data;
                });
        };

        vm.showOrderLines = function (orderID) {
            vm.Lines = [];
            angular.forEach(vm.orders,
                function (ord) {
                    if (ord.id == orderID) {
                        angular.forEach(ord.orderlines,
                            function (line) {
                                vm.Lines.push(line);
                            });
                        console.debug(vm.Lines);
                    }
                });
        };
    }
}());