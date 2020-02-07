<%@ Page Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="SignIn.aspx.cs" Inherits="WebApplication.WebForm1" %>
<asp:Content ID="contentHead" runat="server" ContentPlaceHolderID="head">
    </asp:Content>
        <asp:Content ID="contentPlaceHolderSignIn" runtat="server" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <table>
            <tr>
                <td>User Name</td>
                <td><asp:TextBox runat="server" type="email" id="txtUser"/></td>
            </tr>
            <tr>
                <td>Password</td>
                <td><asp:TextBox runat="server" type="password" id="txtPassword" /></td>
            </tr>
        </table>
        <asp:Button runat="server" text="SignIn" OnClick="SignIn"></asp:Button>
        <asp:Button runat="server" text="SignUp" OnClick="SignUp"></asp:Button>
   </asp:Content>
