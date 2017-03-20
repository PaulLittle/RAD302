(function () {
    "use strict";

    angular
    .module("common.services")
    .factory("orderResource",
    ["$resource",
        "appSettings",
        orderResource])

    function orderResource($resource, appSettings) {
        return {
            Orders: $resource(appSettings.serverPath + "/api/orders/"),
            OrdersWithProducts: $resource(appSettings.serverPath + "/api/orders/getOrdersWithProducts/ID/:id")
        };
    }
}());