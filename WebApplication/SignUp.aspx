<%@ Page Language="C#" MasterPageFile="MasterPage.Master" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="WebApplication.WebForm2" %>
<asp:Content ID="contentSignUP" runat="server" ContentPlaceHolderID="head">
    </asp:Content>
        <asp:Content ID="contentPlaceHolderSignUp" runtat="server" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       
            <table>
            <tr>
                <td>First Name</td>
                <td>
                    <asp:TextBox runat="server" ID="txtFirst" required="required" placeholder="Enter the fist name" /></td>
                <td>
                    <asp:RequiredFieldValidator ID="validateName" runat="server" ControlToValidate="txtFirst" ErrorMessage="Name required" Style="color: red"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="regularValidateName" runat="server" ControlToValidate="txtFirst" ErrorMessage="Enter valid name" Style="color: red" ValidationExpression="^[A-Za-z]+$"></asp:RegularExpressionValidator>
                 </td>
            </tr>
            <tr>
                <td>Last Name</td>
                <td>
                    <asp:TextBox runat="server" type="text" ID="txtLast" required="required" placeholder="Enter the last name" /></td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorLast" runat="server" ControlToValidate="txtLast" ErrorMessage="Name required" Style="color: red"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidatorLast" runat="server" ControlToValidate="txtLast" ErrorMessage="Enter valid name" Style="color: red" ValidationExpression="^[A-Za-z]+$"></asp:RegularExpressionValidator>
                 </td>
            </tr>
            <tr>
                <td>Mobile Number</td>
                <td>
                    <asp:TextBox runat="server" type="number" ID="txtMobile" required="required" placeholder="Enter the mobile number" /></td>
                 <td>
                     <asp:RequiredFieldValidator ID="validateMobileNumber" runat="server" ControlToValidate="txtMobile" ErrorMessage="Mobile number required" Style="color: red"></asp:RequiredFieldValidator>
                     <asp:RegularExpressionValidator ID="regularValidateMobileNumber" runat="server" ControlToValidate="txtMobile" ErrorMessage="Enter valid mobile number" Style="color: red" ValidationExpression="^[6789]\d{9}$"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td>Mail Id</td>
                <td>
                    <asp:TextBox runat="server" type="email" ID="txtMail" required="required" placeholder="Enter the mail id" /></td>
                <td>
                      <asp:RequiredFieldValidator ID="validateMail" runat="server" ControlToValidate="txtMail" ErrorMessage="Mail id required" Style="color: red"></asp:RequiredFieldValidator>
                      <asp:RegularExpressionValidator ID="regularValidateMailId" runat="server" ControlToValidate="txtMail" ErrorMessage="Enter valid mail id" Style="color: red" ValidationExpression="^[a-z0-9][-a-z0-9._]+@([-a-z0-9]+.)+[a-z]{2,5}$"></asp:RegularExpressionValidator>
                  </td>
            </tr>
            <tr>
                <td>Password</td>
                <td>
                    <asp:TextBox runat="server" type="password" ID="txtPassword" required="required" placeholder="Enter the password" /></td>
                 <td>
                        <asp:RequiredFieldValidator ID="validatePassword" runat="server" ControlToValidate="txtPassword" ErrorMessage="Password required" style="color:red"></asp:RequiredFieldValidator>
                   </td>
            </tr>
            <tr>
                <td>Confirm Password</td>
                <td>
                    <asp:TextBox runat="server" type="password" ID="txtConPassword" required="required" placeholder="Enter the password again" /></td>
                <td>
                    <asp:RequiredFieldValidator runat="server" ID="regiularConfirmPassword" ControlToValidate="txtConPassword" ErrorMessage="Confirm password required" style="color:red"></asp:RequiredFieldValidator>
                    <asp:CompareValidator runat="server" ID="validateConfirmPassword" ControlToValidate="txtConPassword" ControlToCompare="txtPassword" ErrorMessage="Password and Confirm password must be same"></asp:CompareValidator>
                </td>
            </tr>
        </table>
        <asp:Button runat="server" Text="SignUp" OnClick="SignUp_Click"></asp:Button>
    </asp:Content>