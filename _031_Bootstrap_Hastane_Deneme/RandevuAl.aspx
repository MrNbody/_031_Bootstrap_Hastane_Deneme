<%@ Page Title="" Language="C#" MasterPageFile="~/UyeMain.Master" AutoEventWireup="true" CodeBehind="RandevuAl.aspx.cs" Inherits="_031_Bootstrap_Hastane_Deneme.RandevuAl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/ResponsiveTable.css" rel="stylesheet" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="panel panel-primary">
            <div class="panel-body">
                Randevu Al
            </div>
            <div class="panel-footer">

                <asp:ScriptManager ID="sm" runat="server"></asp:ScriptManager>


                <div class="row">
                    <div class="col-lg-12">
                        <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6">
                            <label>Saat</label>
                        </div>
                        <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6">
                            <label class="fr">Hoşgeldiniz</label>
                        </div>
                    </div>
                    <div class="col-lg-12">
                        <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6">
                            <asp:Label ID="labelSaat" runat="server" Text=""></asp:Label>
                        </div>
                        <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6">
                            <asp:Label ID="labelhosgeldiniz" CssClass="fr" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                </div>


                <asp:UpdatePanel ID="up1" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>


                        <div class="row">
                            <asp:Panel ID="panelRandevuAra" runat="server">
                                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 mt15">
                                    <div class="form-group">
                                        <label for="exampleInputEmail1" class="control-label col-sm-1">Şehir</label>
                                        <div class="col-sm-11 col-xs-12">
                                            <asp:DropDownList CssClass="form-control" ID="dropListSehir" runat="server" AutoPostBack="true" OnSelectedIndexChanged="dropListSehir_SelectedIndexChanged"></asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 mt15">
                                    <div class="form-group">
                                        <label for="exampleInputEmail1" class="control-label col-sm-1">İlçe</label>
                                        <div class="col-sm-11 col-xs-12">

                                            <asp:DropDownList CssClass="form-control" ID="dropListIlce" runat="server" AutoPostBack="true" OnSelectedIndexChanged="dropListIlce_SelectedIndexChanged"></asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 mt15">
                                    <div class="form-group">
                                        <label for="exampleInputEmail1" class="control-label col-sm-1">Hastane</label>
                                        <div class="col-sm-11 col-xs-12">

                                            <asp:DropDownList CssClass="form-control" ID="dropListHastane" runat="server" AutoPostBack="true" OnSelectedIndexChanged="dropListHastane_SelectedIndexChanged"></asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 mt15">
                                    <div class="form-group">
                                        <label for="exampleInputEmail1" class="control-label col-sm-1">Klinik</label>
                                        <div class="col-sm-11 col-xs-12">

                                            <asp:DropDownList CssClass="form-control" ID="dropListKlinik" runat="server" AutoPostBack="true" OnSelectedIndexChanged="dropListKlinik_SelectedIndexChanged"></asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 mt15">
                                    <div class="form-group">
                                        <label for="exampleInputEmail1" class="control-label col-sm-1">Doktor</label>
                                        <div class="col-sm-11 col-xs-12">

                                            <asp:DropDownList CssClass="form-control" ID="dropListDoktor" runat="server" OnSelectedIndexChanged="dropListDoktor_SelectedIndexChanged"></asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 mt15">
                                    <div class="form-group">
                                        <label for="exampleInputEmail1" class="control-label col-sm-1">Tarih</label>
                                        <div class="col-sm-11 col-xs-12">
                                            <asp:TextBox TextMode="Date" CssClass="form-control" ID="textboxTarih" placeholder="Randevu Tarihi" runat="server"></asp:TextBox>
                                            <%--                                    <asp:DropDownList ID="dropdawnTarih" CssClass="form-control" runat="server">
                                    </asp:DropDownList>--%>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 mt15">
                                    <div class="form-group">
                                        <div class="col-xs-6">
                                            <asp:Button ID="buttonTemizle" runat="server" CssClass="btn btn-default col-xs-12" Text="Temizle" OnClick="buttonTemizle_Click" />
                                        </div>
                                        <div class="col-xs-6">
                                            <asp:Button ID="buttonRandevuAra" runat="server" CssClass="btn btn-default fr col-xs-12" Text="Randevu Ara" OnClick="buttonRandevuAra_Click" />
                                        </div>
                                    </div>
                                </div>
                            </asp:Panel>
                        </div>


                        <div class="row">


                            <asp:Panel ID="panelDoktorListe" runat="server">
                                <asp:Repeater ID="repeaterDoktor" runat="server">
                                    <HeaderTemplate>
                                        <div class="table-responsive">
                                            <table class="table">
                                                <thead>
                                                    <th>
                                                        <td>Doktor
                                                        </td>
                                                        <td>Hastane
                                                        </td>
                                                        <td>Klinik
                                                        </td>
                                                        <td>Şehir
                                                        </td>
                                                        <td>İlçe
                                                        </td>
                                                    </th>
                                                </thead>
                                                <tbody>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <tr>
                                            <td>
                                                <%--<asp:LinkButton ID="linkbuttonDoktor" CommandArgument='<%#Eval("doktorID") %>' runat="server" OnClick="linkbuttonDoktor_Click" Text="Select"></asp:LinkButton>--%>
                                                <asp:Button ID="buttonDoktor" CssClass="btn btn-link btn-sm" CommandArgument='<%#Eval("doktorID") %>' runat="server" Text="Select" OnClick="buttonDoktor_Click" />
                                            </td>
                                            <td data-label="Doktor">
                                                <%# Eval("doktorAd") %>
                                            </td>
                                            <td data-label="Hastane">
                                                <%# Eval("hastaneAd") %>
                                            </td>
                                            <td data-label="Klinik">
                                                <%# Eval("klinikAd") %>
                                            </td>
                                            <td data-label="Şehir">
                                                <%# Eval("sehirAd") %>
                                            </td>
                                            <td data-label="İlçe">
                                                <%# Eval("ilceAd") %>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        </tbody>
                                </table>
                                    </div>
                                    </FooterTemplate>
                                </asp:Repeater>
                            </asp:Panel>

                        </div>


                        <div class="row">
                            <asp:Panel ID="panelRandevuAl" runat="server" Visible="false">
                                <asp:Repeater ID="repeaterSaat" runat="server" OnItemDataBound="repeaterSaat_ItemDataBound">
                                    <ItemTemplate>
                                        <div class="col-lg-2 col-md-2 col-sm-3 col-xs-4 mt15 text_align">
                                            <%--pl12_5 pl-sm-12-5 pl-md-12-5--%>
                                            <asp:Button ID="btnRandevu" runat="server" CssClass="btn btn-success btn-sm" CommandName="bos" CommandArgument='<%#Eval("mesaiID") %>' Text=' <%#Eval("mesaiSaat").ToString().Substring(0,5) %>' OnClick="btnRandevu_Click"></asp:Button>
                                        </div>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </asp:Panel>
                        </div>



                        <!-- Modal -->
                        <div class="modal fade" id="myModal" role="dialog">
                            <div class="modal-dialog">
                                <!-- Modal content-->
                                <div class="modal-content">
                                    <div id="modal-header" class="modal-header">
                                        <button type="button" class="close" data-dismiss="modal">&times;</button>
                                        <span class="glyphicon glyphicon-question-sign"></span><asp:Label ID="labelModalHeader" runat="server"></asp:Label>
                                    </div>
                                    <div class="modal-body">
                                        <div class="form-group">
                                            <label class="col-xs-4">Doktor</label>
                                            <asp:Label ID="labelModalDoktor" CssClass="col-xs-8" Text="de" runat="server"></asp:Label>
                                        </div>
                                        <div class="form-group">
                                            <label class="col-xs-4">Hasta</label>
                                            <asp:Label ID="labelModalHasta" CssClass="col-xs-8" Text="de" runat="server"></asp:Label>
                                        </div>
                                        <div class="form-group">
                                            <label class="col-xs-4">Tarih</label>
                                            <asp:Label ID="labelModalTarih" CssClass="col-xs-8" Text="de" runat="server"></asp:Label>
                                        </div>
                                        <div class="form-group">
                                            <label class="col-xs-4">Saat</label>
                                            <asp:Label ID="labelModalSaat" CssClass="col-xs-8" Text="de" runat="server"></asp:Label>
                                        </div>
                                        <div class="form-group">
                                            <label class="col-xs-4">Hastane</label>
                                            <asp:Label ID="labelModalHastane" CssClass="col-xs-8" Text="de" runat="server"></asp:Label>
                                        </div>
                                        <div class="form-group">
                                            <label class="col-xs-4">Klinik</label>
                                            <asp:Label ID="labelModalKlinik" CssClass="col-xs-8" Text="de" runat="server"></asp:Label>
                                        </div>
                                        <asp:Panel ID="panelModalDetay" runat="server">
                                            <div class="form-group">
                                                <asp:Button PostBackUrl="~/RandevuAl.aspx" ID="buttonDetayRandevuAl" runat="server" CssClass="btn btn-default col-xs-12" Text="Randevu Al" OnClick="buttonDetayRandevuAl_Click" />
                                            </div>
                                        </asp:Panel>
                                    </div>
                                </div>
                            </div>
                        </div>
        
                    </ContentTemplate>
                </asp:UpdatePanel>



            </div>
        </div>
    </div>
    <script>
        function modalHeaderYesil() {
                document.getElementById("modal-header").className = "modal-header modal-yesil";
        }
    </script>
    <script>
        function modalHeaderKirmizi() {
                document.getElementById("modal-header").className = "modal-header modal-kirmizi";
        }
    </script>
</asp:Content>
