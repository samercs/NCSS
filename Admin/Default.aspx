<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Admin_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h1 class="Title BorderBottom">الصفحة الرئيسية</h1>
    <div class="PagesItems">
        <a href="AdminList.aspx">
            <div class="item">
                <div class="clear sp20"></div>
                <i class="fa fa-lock fa-4x"></i>
                <br />
                <p>
                    مدير الموقع
                </p>

            </div>
        </a>
        <a href="PagesList.aspx">
            <div class="item">
                <div class="clear sp20" "></div>
                <i class="fa fa-file-text-o fa-4x"></i>
                <br />
                <p>
                    صفحات الموقع
                </p>

            </div>
        </a>
        <a href="AboutPagesList.aspx">
            <div class="item">
                <div class="clear sp20" "></div>
                <i class="fa fa-file-text-o fa-4x"></i>
                <br />
                <p>
                    صفحات عن المركز
                </p>

            </div>
        </a>
        <a href="LabelList.aspx">
            <div class="item">
                <div class="clear sp20"></div>
                <i class="fa fa-list fa-4x"></i>
                <br />
                <p>
                   النصوص
                </p>

            </div>
        </a>
        <a href="ShowCaseList.aspx">
            <div class="item">
                <div class="clear sp20"></div>
                <i class="fa fa-picture-o fa-4x"></i>
                <br />
                <p>
                    الشريط المتحرك
                </p>

            </div>
        </a>
        <a href="LibraryList.aspx">
            <div class="item">
                <div class="clear sp20"></div>
                <i class="fa fa-pencil-square-o fa-4x"></i>
                <br />
                <p>
                    المكتبة
                </p>

            </div>
        </a>
        
        <a href="ImagesList.aspx">
            <div class="item">
                <div class="clear sp20"></div>
                <i class="fa fa-file-image-o fa-4x"></i>
                <br />
                <p>
                    صور الموقع
                </p>

            </div>
        </a>
        <a href="ResearcherList.aspx">
            <div class="item">
                <div class="clear sp20"></div>
                <i class="fa fa-file-image-o fa-4x"></i>
                <br />
                <p>
                    الباحثين
                </p>

            </div>
        </a>
        <a href="ResearchMsg.aspx">
            <div class="item">
                <div class="clear sp20"></div>
                <i class="fa fa-male fa-4x"></i>
                <br />
                <p>
                    مراسلة الباحثين
                </p>

            </div>
        </a>
        <a href="SocialEventList.aspx">
            <div class="item">
                <div class="clear sp20"></div>
                <i class="fa fa-list fa-4x"></i>
                <br />
                <p>
                    الظواهر الاجتماعية
                </p>

            </div>
        </a>
        <a href="EventList.aspx">
            <div class="item">
                <div class="clear sp20"></div>
                <i class="fa fa-bus fa-4x"></i>
                <br />
                <p>
                    الاحداث و النشاطات
                </p>

            </div>
        </a>
        <a href="PublicationsList.aspx">
            <div class="item">
                <div class="clear sp20"></div>
                <i class="fa fa-book fa-4x"></i>
                <br />
                <p>
                   المنشورات
                </p>

            </div>
        </a>
        <a href="ContactUsList.aspx">
            <div class="item">
                <div class="clear sp20"></div>
                <i class="fa fa-inbox fa-4x"></i>
                <br />
                <p>
                   البريد الوارد
                </p>

            </div>
        </a>
        <a href="PollList.aspx">
            <div class="item">
                <div class="clear sp20"></div>
                <i class="fa fa-list fa-4x"></i>
                <br />
                <p>
                   استطلاعات الراي
                </p>

            </div>
        </a>
        <a href="PartnersList.aspx">
            <div class="item">
                <div class="clear sp20"></div>
                <i class="fa fa-user fa-4x"></i>
                <br />
                <p>
                   الشركاء
                </p>

            </div>
        </a>
        <a href="NewsLetterList.aspx">
            <div class="item">
                <div class="clear sp20"></div>
                <i class="fa fa-mail-forward fa-4x"></i>
                <br />
                <p>
                   القائمة البريدية
                </p>

            </div>
        </a>
        <a href="RelatedLinksList.aspx">
            <div class="item">
                <div class="clear sp20"></div>
                <i class="fa fa-link fa-4x"></i>
                <br />
                <p>
                   جهات ذات علاقة
                </p>

            </div>
        </a>
        <a href="ReportDataList.aspx">
            <div class="item">
                <div class="clear sp20"></div>
                <i class="fa fa-pie-chart fa-4x"></i>
                <br />
                <p>
                   إحصائيات الموقع 
                </p>

            </div>
        </a>
    </div>
    <h1 class="Title BorderBottom">المركز الاعلامي</h1>
    <div class="PagesItems">
        <a href="NewsList.aspx">
            <div class="item">
                <div class="clear sp20"></div>
                <i class="fa fa-hacker-news fa-4x"></i>
                <br />
                <p>
                    الاخبار
                </p>

            </div>
        </a>
        <a href="VedioList.aspx">
            <div class="item">
                <div class="clear sp20"></div>
                <i class="fa fa-youtube fa-4x"></i>
                <br />
                <p>
                    الفيديو
                </p>

            </div>
        </a>
        <a href="ReportList.aspx">
            <div class="item">
                <div class="clear sp20"></div>
                <i class="fa fa-bar-chart fa-4x"></i>
                <br />
                <p>
                    التقارير
                </p>

            </div>
        </a>
        <a href="AlbumsList.aspx">
            <div class="item">
                <div class="clear sp20"></div>
                <i class="fa fa-bar-chart fa-4x"></i>
                <br />
                <p>
                    البوم الصور
                </p>

            </div>
        </a>
     </div>
</asp:Content>
