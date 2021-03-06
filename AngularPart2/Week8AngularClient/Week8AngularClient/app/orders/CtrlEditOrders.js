﻿(function () {
    "use strict";

    angular
    .module("orderManagement")
    .controller("EditOrderCtrl",
                 EditOrderCtrl);

    function EditOrderCtrl(orderResource) {
        var vm = this;
        vm.customer = {};
        orderResource.GetCids(
            function (data) {
                vm.customer = data;
            });
        vm.selectedIndex = 0;
        vm.order = []; //vm.customer[1].order;
        vm.updateList = function () {
            vm.order = vm.customer[vm.selectedIndex].order;
        };
        //vm.Ids = [];
        //vm.Oids = [];
        vm.message = '';

        orderResource.GetOrders(
        function (data) {
            vm.order = data;
            vm.originalOrder = angular.copy(data);
        });

        vm.getOrderWithProducts = function (OrderId) {
            orderResource.OrdersWithProducts.query({ id: OrderId },
                function (data) {
                    vm.productOrderLines = data;
                });
        };
        
        if (vm.order && vm.order.Id) {
            vm.title = "Edit: " + vm.order.Id;
        }
        else {
            vm.title = "New Order";
        }

        vm.changed = function (selectedItem) {
            orderResource.get({ id: selectedItem },
                function (data) {
                    vm.order = data;
                    vm.originalOrder = angular.copy(data);
        });
        }

        vm.submit = function () {
            vm.message = '';
            if (vm.order.Id) {
                vm.order.$update({ id: vm.order.Id },
                    function (data) {
                        vm.message = "... Save Complete";
                    })
            }
            else {
                vm.order.$save(
                    function (data) {
                        vm.originalOrder = angular.copy(data);

                        vm.message = "... Save Complete";
                    })
            }
        };

        vm.cancel = function (editForm) {
            editForm.$setPristine();
            vm.order = angular.copy(vm.originalOrder);
            vm.message = "";
        };
    }
}());