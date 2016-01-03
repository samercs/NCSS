<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Facebook.ascx.cs" Inherits="controls_Facebook" %>
      <div class="Facebook">
                <div>
                    <div id="fb-root">
                    </div>
                    <script>
                    (function (d, s, id) {
                        var js, fjs = d.getElementsByTagName(s)[0];
                        if (d.getElementById(id)) return;
                        js = d.createElement(s); js.id = id;
                        js.src = "//connect.facebook.net/en_US/all.js#xfbml=1&appId=155867894492292";
                        fjs.parentNode.insertBefore(js, fjs);
                    }(document, 'script', 'facebook-jssdk'));</script>
                    <div class="fb-like-box Hidden800" data-href="https://www.facebook.com/NCSSKSA?fref=ts"
                         data-width="300" data-show-faces="true" data-stream="true" data-header="true">
                    </div>
                </div>
            </div>