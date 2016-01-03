<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Footer.ascx.cs" Inherits="controls_Footer" %>
<div class="modal fade" id="login-modal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" style="display: none;">
    	  <div class="modal-dialog">
				<div class="loginmodal-container">
					<h1><%= new Lang().getByKey("SubscribeToOurMailingList") %></h1><br>
				  <form>
					<input type="text" class="FontText" id="txtNameSB" name="user" placeholder="<%= new Lang().getByKey("Name") %>">
					<input type="text" class="FontText" id="txtEmailSB" name="pass" placeholder="<%= new Lang().getByKey("Email") %>">
					<input type="button" id="btnSubscripe"  name="Submit" class="btn login btn-primary" value="<%= new Lang().getByKey("Submit") %>">
				  </form>
				</div>
			</div>
		  </div>


<footer class=" ">
    <div class="container">
        <nav>
            <ul>
                <li><a href="/Default.aspx"><%= new Lang().getByKey("Home") %></a></li>
                <li><a href="/Careers.aspx"><%= new Lang().getByKey("Careers") %></a></li>
                <li><a data-toggle="modal" href="#" data-target="#login-modal"><%= new Lang().getByKey("SubscribeToOurMailingList") %></a></li>
                <li><a href="/Experts.aspx"><%= new Lang().getByKey("Researchers") %></a></li>
                <li><a href="/Privacy.aspx"><%= new Lang().getByKey("PrivacyPolicy") %></a></li>
                <li><a href="/ContactUs.aspx"><%= new Lang().getByKey("ContactUs") %></a></li>
            </ul>
        </nav>
    </div>
      <div class="Footerline">
          <%= new Lang().getByKey("CopyRight") %> <%=DateTime.Now.Year %>
        </div>
        <img id="BottomRightImage2" class="img-responsive" src="/images/BottomBack2.png" />
        <img id="BottomRightImage" class="img-responsive" src="/images/BottomBack.png" />
</footer>

<script type="text/javascript">
    $(function() {

        $("#btnSubscripe").click(function() {
            
            if (validateData()) {
                var name = $("#txtNameSB").val();
                var email = $("#txtEmailSB").val();
                
                $.ajax({
                    url: "/ajax/NewsLetterSubscripe.ashx?name="+name+"&email="+email, success: function (result) {
                        $('#login-modal').modal('hide');
                        alertify.success("<%=new Lang().getByKey("NewsLetterSuccess")%>");

                    }, error : function() {
                        $('#login-modal').modal('hide');
                        alertify.error("<%=new Lang().getByKey("NewsLetterError")%>");
                    }
                });
            }

        });

        validateData = function() {
            var name = $("#txtNameSB").val();
            var email = $("#txtEmailSB").val();
            alertify.dismissAll();
            if (name.length == 0) {
                alertify.error("<%=new Lang().getByKey("NameError")%>");
                return false;
            }

            if (email.length == 0) {
                alertify.error("<%=new Lang().getByKey("EmailError")%>");
                return false;
            }
            if (!validateEmail(email)) {
                alertify.error("<%=new Lang().getByKey("EmailError2")%>");
                return false;
            }

            return true;


        };

        validateEmail=function (email) {
            var re = /^([\w-]+(?:\.[\w-]+)*)@((?:[\w-]+\.)*\w[\w-]{0,66})\.([a-z]{2,6}(?:\.[a-z]{2})?)$/i;
            return re.test(email);
        }

    });
</script>
