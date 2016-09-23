<%@ Page Title="" Language="C#" MasterPageFile="~/doktor/DoktorMain.Master" AutoEventWireup="true" CodeBehind="HesapBilgileri.aspx.cs" Inherits="_031_Bootstrap_Hastane_Deneme.doktor.HesapBilgileri" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <div class="container-fluid">
        <div class="panel panel-primary">
            <div class="panel-body">
                Hesap Bilgileri
            </div>
            <div class="panel-footer">
                <asp:ScriptManager ID="sm" runat="server"></asp:ScriptManager>
                <asp:UpdatePanel ID="up" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                <div class="form-group">
                    <label for="exampleInputEmail1" class="col-sm-2 control-label">Tc No</label>
                    <div class="col-sm-10">
                        <asp:TextBox CssClass="form-control" ID="textboxTc" placeholder="Tc no" ReadOnly runat="server"></asp:TextBox>
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
                        <asp:TextBox CssClass="form-control" ID="textboxCinsiyet" placeholder="Cinsiyet" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <label for="exampleInputPassword1" class="col-sm-2 control-label">Telefon</label>
                    <div class="col-sm-10">
                        <asp:TextBox CssClass="form-control" ID="textboxTelefon" placeholder="Telefon" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <label for="exampleInputPassword1" class="col-sm-2 control-label">Email</label>
                    <div class="col-sm-10">
                        <asp:TextBox TextMode="Email" CssClass="form-control" ID="textboxEmail" placeholder="Email" runat="server"></asp:TextBox>
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
