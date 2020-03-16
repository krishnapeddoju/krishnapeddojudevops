function toast() {
    //angular.element(document.getElementById('tt')).scope().Angulartoast();
    toastr.success('Click Button');
    var delay =6000;
    setTimeout(function () {
    }, delay);
}

var app = angular.module('myApp',[]);

app.controller("resetPasswordController", function ($scope) {

     $scope.isEmailSucces = ($('#isemailSuccess').text() == 'true');

});

app.controller("sessionExpiredController", function ($scope) {
    $scope.loggedApplication = $('#loggedApplication').text();

    $scope.CargoAngularUrl = $('#CargoAngularUrl').text();
    $scope.BagManagementAngularUrl = $('#BagManagementAngularUrl').text();
    $scope.ImportWebAppAngularUrl = $('#ImportWebAppAngularUrl').text();
    $scope.MasterDataAngularUrl = $('#MasterDataAngularUrl').text();
    $scope.BillingAngularUrl = $('#BillingAngularUrl').text();
    $scope.backToLogin = function () {
        window.location.href = $('#RedirectApplicationUrl').text();
    }

});
app.controller("emailsentController", function ($scope) {

    $scope.isEmailSucces = $('#status').text() == "True";
    $scope.errorMsg = $('#errorMsg').text();

});
   app.controller('forgotPasswordController',
function ($scope, $http) {
    var userModel = {};
    $scope.userName = $('#loginusername').text();
    $scope.PrevPwdCheck = "";
    $scope.Password = $('#loginpassword').val();
    $scope.LogTransId = $('#logTransId').text();
    $scope.newPassword = "";
    $scope.ConfirmPassword = "";
    $scope.errorMessage = "";
    $scope.signin = $('#loginsignin').text();
    
   // $scope.loggedApplication = $('#loggedApplication').text();

    $scope.UAMApi = $('#UAMApi').text();

          
    $scope.saveForgotPassword = function () {
        $('#errorMsg').text('');
        userModel = {
            UserName: $scope.userName,
                       
            Password: $scope.Password,
            NewPassword: $scope.newPassword,
            LogTransId: $scope.LogTransId
        }
        return $http.post($scope.UAMApi + '/api/Account/ForgotPassword', userModel).then(function (response) {
            if (JSON.parse(response.data) === "Success") {

                window.location.href = $('#RedirectApplicationUrl').text();
            } else {
                $scope.PrevPwdCheck = userModel.NewPassword;
                $scope.errorMessage = response.data;
            }
        });
    }
            
}
    );
var newPassword = "";
var ConfirmPassword = "";

