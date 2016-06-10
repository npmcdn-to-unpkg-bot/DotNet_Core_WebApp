angular.module('br').controller('appUserCtrl', function ($scope, $http, $modal) {
    $scope.appUsers = [];

    init();
    function init() {
        $http.get('/api/account').then(function (result) {
            if (result.data.error) {
                alert(result.data.error);
            }
            else {
                $scope.appUsers = result.data;
            }
        },
        function (error) {
            alert(error);
        });
    }

    function addAppUser() {

    }
});
