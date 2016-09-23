<%@ Page Title="" Language="C#" MasterPageFile="~/doktor/DoktorMain.Master" AutoEventWireup="true" CodeBehind="RandevuGecmisi.aspx.cs" Inherits="_031_Bootstrap_Hastane_Deneme.doktor.RandevuGecmisi" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/ResponsiveTable.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container-fluid">
        <div class="panel panel-primary">
            <div class="panel-body">
                Randevu Geçmişi
            </div>
            <div class="panel-footer">
                <asp:ScriptManager ID="sm" runat="server"></asp:ScriptManager>
                <asp:UpdatePanel ID="up" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div class="form-group">
                                <label for="exampleInputEmail1" class="col-xs-12 col-sm-2 control-label mt15 text_left">Tarih Aralığı</label>
                            <div class="col-xs-12 col-sm-3 mt15">
                                <asp:TextBox TextMode="Date" ID="textboxTarihBaslangic" CssClass="form-control col-xs-6" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-xs-12 col-sm-3 mt15">
                                <asp:TextBox TextMode="Date" ID="textboxTarihBitis" CssClass="form-control col-xs-6" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-xs-12 col-sm-4 mt15">
                                <asp:Button ID="buttonRandevuGecmisAra" CssClass="btn btn-default col-xs-12" Text="Randevu Geçmişi" OnClick="buttonRandevuGecmisAra_Click" runat="server" />
                            </div>
                        </div>
                        <asp:Repeater ID="repeaterRandevuGecmis" runat="server" OnItemDataBound="repeaterRandevuGecmis_ItemDataBound">
                            <HeaderTemplate>
                                <div class="table-responsive">
                                    <table class="table">
                                        <thead>
                                            <tr>
                                                <th>#</th>
                                                <th>Hasta
                                                </th>
                                                <th>Tarih
                                                </th>
                                                <th>Hastane
                                                </th>
                                                <th>Klinik
                                                </th>
                                                <th>Şehir
                                                </th>
                                                <th>İlçe
                                                </th>
                                                <th>Durum
                                                </th>
                                            </tr>
                                        </thead>
                                        <tbody>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr>
                                    <td data-label="#">
                                        <asp:Button ID="buttonDoktor" runat="server" CssClass="btn btn-default btn-sm" CommandArgument='<%# Eval("randevuID") %>' Text="İptal Et" OnClick="buttonDoktor_Click" OnClientClick="acModal()" />
                                    </td>
                                    <td data-label="Doktor">
                                        <%# Eval("uyeAd") %>
                                    </td>
                                    <td data-label="Tarih">
                                        <%# Convert.ToDateTime(Eval("randevuTarihSaat")) %>
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
                                    <td data-label="Durum">
                                        <asp:Label ID="labelRandevuDurum" runat="server"></asp:Label>
                                    </td>
                                </tr>
                            </ItemTemplate>
                            <FooterTemplate>
                                </tbody>
                        </table>
                        </div>
                            </FooterTemplate>
                        </asp:Repeater>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div><!-- Modal -->
        <div class="modal fade" id="myModal" role="dialog">
            <div class="modal-dialog">
                <!-- Modal content-->
                <div class="modal-content">
                    <div class="modal-header modal-kirmizi">
                        <button type="button" class="close" data-dismiss="modal">&times;</button>
                        <h4><span class="glyphicon glyphicon-question-sign"></span>Emin misiniz</h4>
                    </div>
                    <div class="modal-body">
                        <h5><span class="glyphicon"></span>Randevunuz iptal edilecektir!</h5>
                        <div class="form-group">
                            <button type="submit" class="btn btn-danger pull-left col-xs-5" data-dismiss="modal"><span class="glyphicon glyphicon-remove"></span>Hayır</button>
                            <asp:LinkButton ID="buttonLogin" CssClass="btn btn-success pull-right col-xs-5" runat="server" Text="Evet" OnClick="buttonLogin_Click"><span class="glyphicon glyphicon-ok"></span> Evet</asp:LinkButton>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
