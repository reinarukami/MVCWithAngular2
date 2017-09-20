var app = angular.module("MyApp", [])

app.controller("RegisterController", function ($scope, RegisterService) {

    $scope.submitText = "Save";
    $scope.submitted = false;
    $scope.message = '';
    $scope.isFormValid = false;
    $scope.Login = {
        Username: '',
        Password: '',
        FullName: '',
        Email: '',
        Gender: ''
    };

    $scope.$watch('f1.$valid', function (value) {
        $scope.isFormValid = value;
    });

    $scope.SaveData = function (data) {
        if ($scope.submitText == 'Save') {
            $scope.submitted = true;
            $scope.message = '';

            if ($scope.isFormValid) {
                $scope.submitText = 'Please wait';
                $scope.User = data;
                RegisterService.SaveFormData($scope.User).then(function (data) {
                    alert(data);
                    if (data == 'Success') {

                    }
                    $scope.submitText = "Save";
                });
            }
            else {
                $scope.message = 'Please fill required fields value';
            }
        }

        function ClearForm() {
            $scope.User = {};
            $scope.f1.$setPristine();
            $scope.submitted = false;
        }

    }

}).factory("RegisterService", function ($http, $q) {

    var fac = {};
    fac.SaveFormData = function (data) {
        var defer = $q.defer();
        $http({
            url: '/Data/AddUser',
            method: 'POST',
            data: JSON.stringify(data),
            headers: { 'content-type': 'application/json' }
        }).success(function (d) {
            //Success callback
            defer.resolve(d);
        }).error(function (e) {
            //Fail Callback
            alert('Error!');
            defer.reject(e);
        });

        return defer.promise;

    }

    return fac;

});