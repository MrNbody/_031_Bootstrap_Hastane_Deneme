<%@ Page Title="" Language="C#" MasterPageFile="~/doktor/DoktorMain.Master" AutoEventWireup="true" CodeBehind="CalismaSaatleri.aspx.cs" Inherits="_031_Bootstrap_Hastane_Deneme.doktor.CalismaSaatleri" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container-fluid">
        <div class="panel panel-primary">
            <div class="panel-body">
                Çalışma Saatleri
            </div>
            <div class="panel-footer">
                <asp:ScriptManager ID="sm" runat="server"></asp:ScriptManager>
                <asp:UpdatePanel ID="up" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                <div class="form-group">
                    <label for="exampleInputEmail1" class="col-lg-2 col-md-3 col-sm-3 control-label">Başlama Saati</label>
                    <div class="col-lg-10 col-md-9 col-sm-9">
                        <asp:TextBox CssClass="form-control" TextMode="Time" ID="textboxBaslamaSaati" placeholder="Başlama Saati" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <label for="exampleInputPassword1" class="col-lg-2 col-md-3 col-sm-3 control-label">Bitiş Saati</label>
                    <div class="col-lg-10 col-md-9 col-sm-9">
                        <asp:TextBox CssClass="form-control" TextMode="Time" ID="textboxBitisSaati" placeholder="Bitiş Saati" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <label for="exampleInputPassword1" class="col-lg-2 col-md-3 col-sm-3 control-label">Çalışma Periyodu</label>
                    <div class="col-lg-10 col-md-9 col-sm-9">
                        <asp:TextBox CssClass="form-control" TextMode="Time" ID="textboxCalismaPeriyodu" placeholder="Çalışma Periyodu" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <label for="exampleInputPassword1" class="col-lg-2 col-md-3 col-sm-3 control-label">Öğle Başlangıç Saati</label>
                    <div class="col-lg-10 col-md-9 col-sm-9">
                        <asp:TextBox CssClass="form-control" TextMode="Time" ID="textboxOgleBaslangıcSaati" placeholder="Öğle Başlangıç Saati" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <label for="exampleInputPassword1" class="col-lg-2 col-md-3 col-sm-3 control-label">Öğle Bitiş Saati</label>
                    <div class="col-lg-10 col-md-9 col-sm-9">
                        <asp:TextBox CssClass="form-control" TextMode="Time" ID="textboxOgleBitisSaati" placeholder="Öğle Bitiş Saati" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-xs-12">
                        <asp:Button ID="buttonKaydet" CssClass="btn btn-default col-xs-12" runat="server" Text="Kaydet" OnClick="buttonKaydet_Click" />
                    </div>
                </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>

</asp:Content>
