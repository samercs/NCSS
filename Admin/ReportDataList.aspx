<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="ReportDataList.aspx.cs" Inherits="Admin_ReportDataList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h1 class="Title BorderBottom">احصائيات الموقع</h1>
    <script>
        (function (w, d, s, g, js, fs) {
            g = w.gapi || (w.gapi = {}); g.analytics = { q: [], ready: function (f) { this.q.push(f); } };
            js = d.createElement(s); fs = d.getElementsByTagName(s)[0];
            js.src = 'https://apis.google.com/js/platform.js';
            fs.parentNode.insertBefore(js, fs); js.onload = function () { g.load('analytics'); };
        }(window, document, 'script'));
    </script>


    <div id="embed-api-auth-container"></div>
    <div id="chart-container"></div>
    <div id="view-selector-container"></div>
    
    <div id="chart-container-2"></div>
    <div id="view-selector-container-2"></div>


    <script>

        gapi.analytics.ready(function () {

            /**
             * Authorize the user immediately if the user has already granted access.
             * If no access has been created, render an authorize button inside the
             * element with the ID "embed-api-auth-container".
             */
            gapi.analytics.auth.authorize({
                container: 'embed-api-auth-container',
                clientid: '536729001209-9fhv9jkr7arqaaq8d5olfmh6v1416dh4.apps.googleusercontent.com'
            });


            /**
             * Create a new ViewSelector instance to be rendered inside of an
             * element with the id "view-selector-container".
             */
            var viewSelector = new gapi.analytics.ViewSelector({
                container: 'view-selector-container'
            });

            var viewSelector2 = new gapi.analytics.ViewSelector({
                container: 'view-selector-container-2'
            });

            // Render the view selector to the page.
            viewSelector.execute();
            viewSelector2.execute();

            /**
             * Create a new DataChart instance with the given query parameters
             * and Google chart options. It will be rendered inside an element
             * with the id "chart-container".
             */
            var dataChart = new gapi.analytics.googleCharts.DataChart({
                query: {
                    metrics: 'ga:users',
                    dimensions: 'ga:date',
                    'start-date': '30daysAgo',
                    'end-date': 'yesterday'
                },
                chart: {
                    container: 'chart-container',
                    type: 'LINE',
                    options: {
                        width: '100%'
                    }
                }
            });

            var dataChart2 = new gapi.analytics.googleCharts.DataChart({
                query: {
                    metrics: 'ga:sessions',
                    dimensions: 'ga:date',
                    'start-date': '30daysAgo',
                    'end-date': 'yesterday'
                },
                chart: {
                    container: 'chart-container-2',
                    type: 'LINE',
                    options: {
                        width: '100%'
                    }
                }
            });


            /**
             * Render the dataChart on the page whenever a new view is selected.
             */
            viewSelector.on('change', function (ids) {
                dataChart.set({ query: { ids: ids } }).execute();
            });

            viewSelector2.on('change', function (ids) {
                dataChart2.set({ query: { ids: ids } }).execute();
            });

        });
    </script>
</asp:Content>

