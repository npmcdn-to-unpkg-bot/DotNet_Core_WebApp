angular.module('br').controller('addAppUserCtrl', function ($scope, $modalInstalce) {
    $scope.close = function () {
        $modalInstalce.dismiss();
    };

    $scope.commit = function () {
        alert("ok");
    };
});