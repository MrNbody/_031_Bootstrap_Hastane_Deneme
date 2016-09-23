<%@ Page Title="" Language="C#" MasterPageFile="~/admin/AdminMain.Master" AutoEventWireup="true" CodeBehind="Hastane.aspx.cs" Inherits="_031_Bootstrap_Hastane_Deneme.admin.Hastane" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container-fluid">
        <div class="panel panel-primary">
            <div class="panel-body">
                Hastane
            </div>
            <div class="panel-footer">
                <asp:ScriptManager ID="sm" runat="server"></asp:ScriptManager>
                <asp:UpdatePanel ID="up" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div class="form-group">
                            <label for="exampleInputEmail1" class="col-sm-2 control-label">Şehir</label>
                            <div class="col-sm-10">
                                <asp:DropDownList CssClass="form-control" ID="dropListSehir" runat="server" AutoPostBack="true" OnSelectedIndexChanged="dropListSehir_SelectedIndexChanged"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="exampleInputEmail1" class="control-label col-sm-2">İlçe</label>
                            <div class="col-sm-10">
                                <asp:DropDownList CssClass="form-control" ID="dropListIlce" runat="server"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="exampleInputEmail1" class="control-label col-sm-2">Hastane</label>
                            <div class="col-sm-10">
                                <asp:TextBox CssClass="form-control" ID="textboxHastane" runat="server"></asp:TextBox>
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
