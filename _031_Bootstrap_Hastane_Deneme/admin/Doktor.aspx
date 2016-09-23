<%@ Page Title="" Language="C#" MasterPageFile="~/admin/AdminMain.Master" AutoEventWireup="true" CodeBehind="Doktor.aspx.cs" Inherits="_031_Bootstrap_Hastane_Deneme.admin.Doktor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container-fluid">
        <div class="panel panel-primary">
            <div class="panel-body">
                Doktor
            </div>
            <div class="panel-footer">
                <asp:ScriptManager ID="sm" runat="server"></asp:ScriptManager>
                <asp:UpdatePanel ID="up" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div class="form-group">
                            <label for="exampleInputEmail1" class="col-sm-2 control-label">Tc No</label>
                            <div class="col-sm-10">
                                <asp:TextBox CssClass="form-control" ID="textboxTc" placeholder="Tc no" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="exampleInputPassword1" class="col-sm-2 control-label">Ad</label>
                            <div class="col-sm-10">
                                <asp:TextBox CssClass="form-control" ID="textboxAd" placeholder="Ad" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="exampleInputPassword1" class="col-sm-2 control-label">Soyad</label>
                            <div class="col-sm-10">
                                <asp:TextBox CssClass="form-control" ID="textboxSoyad" placeholder="Soyad" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="exampleInputPassword1" class="col-sm-2 control-label">Cinsiyet</label>
                            <div class="col-sm-10">
                                <asp:DropDownList ID="dropdownlistCinsiyet" CssClass="form-control" placeholder="Cinsiyet" runat="server">
                                    <asp:ListItem>Erkek</asp:ListItem>
                                    <asp:ListItem>Kadın</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="exampleInputPassword1" class="col-sm-2 control-label">Telefon</label>
                            <div class="col-sm-10">
                                <asp:TextBox CssClass="form-control" ID="textboxTelefon" placeholder="örn. 0123 123 12 12" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="exampleInputEmail1" class="col-sm-2 control-label">Şehir</label>
                            <div class="col-sm-10">
                                <asp:DropDownList CssClass="form-control" ID="dropListSehir" runat="server" AutoPostBack="true" OnSelectedIndexChanged="dropListSehir_SelectedIndexChanged"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="exampleInputEmail1" class="control-label col-sm-2">İlçe</label>
                            <div class="col-sm-10">
                                <asp:DropDownList CssClass="form-control" ID="dropListIlce" runat="server" AutoPostBack="true" OnSelectedIndexChanged="dropListIlce_SelectedIndexChanged"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="exampleInputEmail1" class="control-label col-sm-2">Hastane</label>
                            <div class="col-sm-10">
                                <asp:DropDownList CssClass="form-control" ID="dropListHastane" runat="server" AutoPostBack="true" OnSelectedIndexChanged="dropListHastane_SelectedIndexChanged"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="exampleInputEmail1" class="control-label col-sm-2">Klinik</label>
                            <div class="col-sm-10">
                                <asp:DropDownList CssClass="form-control" ID="dropListKlinik" runat="server" AutoPostBack="true"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="exampleInputPassword1" class="col-sm-2 control-label">Email</label>
                            <div class="col-sm-10">
                                <asp:TextBox TextMode="Email" CssClass="form-control" ID="textboxEmail" placeholder="email@email.com" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="exampleInputPassword1" class="col-sm-2 control-label">Parola</label>
                            <div class="col-sm-10">
                                <asp:TextBox TextMode="Password" CssClass="form-control" ID="textboxParola" placeholder="Parola" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-xs-12">
                                <asp:Button ID="buttonKayıt" CssClass="btn btn-default col-xs-12" runat="server" Text="Kaydet" OnClick="buttonKayıt_Click" />
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>

</asp:Content>
