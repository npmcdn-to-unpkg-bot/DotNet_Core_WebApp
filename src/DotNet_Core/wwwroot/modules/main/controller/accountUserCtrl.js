
angular.module("br").controller('br.accountUserCtrl', AccountUserCtrl);
AccountUserCtrl.$inject = ['$scope', '$http'];

function AccountUserCtrl($scope, $http) {
    $scope.accountUsers = [];
    init();

    function init() {
        $http.get("/api/account").then(function (result) {
            if (result.data.error) {
                alert(result.data.error);
            }
            else {
                $scope.accountUsers = result.data;
            }
        }, function () {

        });
    }
};



