<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Login.ascx.cs" Inherits="Survey.Net.Engine.Modules.Login" %>
<style type="text/css">
    html { background:url(Static/Images/login-wall.jpg) no-repeat center top; }
    body { background:none; }
</style>
<div class="container" id="login-container">
	<div class="content">
		<div class="row">
			<div class="login-form">
				<h2>Login</h2>
				<form id="loginForm">
					<fieldset>
						<div class="clearfix">
                            <label for="Username">Username</label>
							<input type="text" class="span4" placeholder="Username" id="Username" name="Username" tabindex="10">
						</div>
						<div class="clearfix">
                            <label for="Password">Password</label>
							<input type="password" class="span4" placeholder="Password" id="Password" name="Password" tabindex="20">
						</div>
						<button class="btn btn-primary" id="LoginButton" name="LoginButton" type="button" tabindex="30">Login</button>
					</fieldset>
				</form>
                <div id="login-process" style="margin-top:10px;">
                    <div class="progress progress-striped active">
                        <div class="bar" style="width:100%;">
                            Please wait...
                        </div>
                    </div>
                </div>
                <div id="login-error">
                    <div class="alert alert-error" style="margin-top:10px;">
                        User not found.
                    </div>
                </div>
                <div id="login-success">
                    <div class="alert alert-success" style="margin-top:10px;">
                        Login success, please wait. Redirecting...
                    </div>
                </div>
			</div>
		</div>
	</div>
</div>