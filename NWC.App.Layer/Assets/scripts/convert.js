app.controller('ConverterCtrl', ['$scope', 'mainGetService', '$http', function ($scope, mainGetService, $http) {

    $('#result').hide();

    $scope.processNumber = function () {
        $('#convert').hide();
        $('#result').show();
        
        //var uri = "http://localhost:49602/api/number/";
        var uri = $('#AppURI').val();
        mainGetService.numberToWord(uri,$scope.number).then(function (response) {
            $scope.result = response.data;

        }, function (err) {
            $scope.result = "Something went wrong. Please check after sometime";
        });;
    };

    $scope.convertNumber = function () {
        $('#convert').show();
        $('#result').hide();
    };
}]);

