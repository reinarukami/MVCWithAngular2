var app = angular.module('MyApp', []);
  
  //in app controller there is the name of the controller that you will declare in html scope and the service that you will use
app.controller('GetCtyStsController', function($scope, GetCtyStsService){

    $scope.CountryID = null;
    $scope.StateID = null;
    $scope.CountryList = null;
    $scope.StateList = null;

    GetCtyStsService.GetCountry().then(function (data) {
        $scope.CountryList = data.data;
    });

    $scope.GetState = function () {
        $scope.StateID = null;
        $scope.StateList = null;
        $scope.StateTextToShow = "Please Wait...";

        GetCtyStsService.GetState($scope.CountryID).then(function (data) {
            $scope.StateList = data.data;
            $scope.StateTextToShow = "Select State";
        }, function (error) {
            alert('Error');
        });
    }

    $scope.ShowResult = function () {
        $scope.Result = "Selected Country ID : " + $scope.CountryID + "State ID: " + $scope.StateID;
    }
})

    //Service name is located and where the api process
.factory('GetCtyStsService', function ($http) {
    var fac = {};
    fac.GetCountry = function () {
        return $http.get('/Data/GetCountries')
    }

    fac.GetState = function (countryID) {
        return $http.get('/Data/GetStates?countryID=' + countryID)
    }

    return fac;
});