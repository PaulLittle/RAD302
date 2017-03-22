(function () {
    "use strict";

    angular
    .module("common.services")
    .factory("orderResource",
    ["$resource",
        "appSettings",
        orderResource])

    function orderResource($resource, appSettings) {
        return $resource(appSettings.serverPath + "/api/customers/:id", null,
            {
                Orders: $resource(appSettings.serverPath + "/api/orders/"),
                OrdersWithProducts: $resource(appSettings.serverPath + "/api/orders/getOrdersWithProducts/ID/:id"),
                Customers: $resource(appSettings.serverPath + "/api/customers/"),
                GetCids: {
                    url: appSettings.serverPath + "/api/customers/GetCids/",
                    method: 'GET', isArray: true
                },
                    update: { method: 'PUT', params: { id: '@id' } },
                    query: { method: 'GET', params: { id: '' }, isArray: true },
                    post: { method: 'POST' },
                    update: { method: 'PUT', params: { id: '@id' } },
                    remove: { method: 'DELETE' }
                })
        };
}());