(function () {
    "use strict";

    angular
    .module("orderManagement")
    .controller("EditOrderCtrl",
                 EditOrderCtrl);

    function EditOrderCtrl(orderResource) {
        var vm = this;
        vm.customer = {};
        vm.Ids = [];
        vm.message = '';

        orderResource.get({id: 0},
        function (data) {
            vm.customer = data;
            vm.originalCustomer = angular.copy(data);
        });

        if (vm.customer && vm.customer.customerId) {
            vm.title = "Edit: " + vm.customer.customerName;
        }
        else {
            vm.title = "New Customer";
        }

        vm.changed = function (selectedItem) {
            orderResource.get({ id: selectedItem },
                function (data) {
                    vm.customer = data;
                    vm.originalCustomer = angular.copy(data);
        });
        }

        orderResource.GetCids(
            function (data) {
                vm.Ids = data;
            });


    }
}());