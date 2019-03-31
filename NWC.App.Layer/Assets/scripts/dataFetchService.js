app.factory('mainGetService', ['$http', function ($http) {

        var mainService = {};

        mainService.numberToWord = function (uri,data) {
            return $http({
                url: uri+data+"/",
                method: "GET",
                headers: {
                    'Content-type': 'application/json'
                }
            });
        };
        return mainService;
}]);

