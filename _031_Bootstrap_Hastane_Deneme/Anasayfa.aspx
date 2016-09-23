<%@ Page Title="" Language="C#" MasterPageFile="~/UyeMain.Master" AutoEventWireup="true" CodeBehind="Anasayfa.aspx.cs" Inherits="_031_Bootstrap_Hastane_Deneme.Anasayfa" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <%--    <script>
        $(function () {
            $("#<%=txtTarih.ClientID %>").datepicker({ dateFormat: 'yy-mm-dd' }).val();
        });
    </script>--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
        <div class="panel panel-primary">
            <div class="panel-body">
                Anasayfa
            </div>
            <div class="panel-footer">
                Hoş Geldiniz<br />
                Randevunuzu 3 adımda alabileceksiniz.<br />
                1. adımda sol taraftaki arama araçlarını kullanarak uygun hekimlerin listesini getirebilirsiniz.<br />
                2. adımda hekim listesinden istediğiniz hekimi seçerek hekim çalışma cetvelini görüntüleyebilirsiniz.<br />
                3. adımda hekim çalışma cetvelinden uygun bir slot seçip randevunuzu kaydedebilirsiniz.
            </div>
        </div>
    </div>

</asp:Content>
