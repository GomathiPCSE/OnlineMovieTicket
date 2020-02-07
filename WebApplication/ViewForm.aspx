<%@ Page Language="C#" MasterPageFile="MasterPage.Master" AutoEventWireup="true" CodeBehind="ViewForm.aspx.cs" Inherits="WebApplication.ViewForm" %>

<asp:Content ID="contentView" runat="server" ContentPlaceHolderID="head">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView ID="idMovieView" runat="server" AutoGenerateColumns="False"
        DataKeyNames="slno" DataSourceID="SqlDataSource1"
        ShowFooter="True">
        <Columns>
            <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
            <asp:TemplateField HeaderText="S.No" InsertVisible="False">
                <EditItemTemplate>
                    <asp:Label ID="txtSlno" runat="server"
                        Text='<%# Eval("slno") %>'>
                    </asp:Label>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="txtSlno" runat="server"
                        Text='<%# Bind("slno") %>'>
                    </asp:Label>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:LinkButton ID="lbInsert" 
                        runat="server" OnClick="lbInsert_Click">Insert
                    </asp:LinkButton>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Movie Name">
                <EditItemTemplate>
                    <asp:TextBox ID="txtMovie" runat="server"
                        Text='<%# Bind("moviename") %>'>
                    </asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvEditName" runat="server"
                        ErrorMessage="Movie Name is a required field"
                        ControlToValidate="txtBox1" Text="*" ForeColor="Red">
                    </asp:RequiredFieldValidator>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="txtMovie" runat="server"
                        Text='<%# Bind("moviename") %>'>
                    </asp:Label>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="txtMovie" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvInsertName" runat="server"
                        ErrorMessage="Movie Name is a required field"
                        ValidationGroup="Insert">
                    </asp:RequiredFieldValidator>
                </FooterTemplate>
            </asp:TemplateField>
        </Columns>
        <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
        <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
        <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
        <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
        <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#FFF1D4" />
        <SortedAscendingHeaderStyle BackColor="#B95C30" />
        <SortedDescendingCellStyle BackColor="#F1E5CE" />
        <SortedDescendingHeaderStyle BackColor="#93451F" />
    </asp:GridView>
    <asp:ValidationSummary ID="ValidationSummary1" ValidationGroup="Insert"
        ForeColor="Red" runat="server" />
    <asp:ValidationSummary ID="ValidationSummary2" ForeColor="Red"
        runat="server" />
    <%--<asp:SqlDataSource ID="SqlDataSource1" runat="server"
        ConnectionString="<%$ ConnectionStrings:SampleConnectionString %>"
        DeleteCommand="DELETE FROM [tblEmployee] WHERE [EmployeeId] = @EmployeeId"
        InsertCommand="INSERT INTO [tblEmployee] ([Name], [Gender], [City]) 
        VALUES (@Name, @Gender, @City)"
        SelectCommand="SELECT * FROM [tblEmployee]"
        UpdateCommand="UPDATE [tblEmployee] SET [Name] = @Name, [Gender] = @Gender,
        [City] = @City WHERE [EmployeeId] = @EmployeeId">
        <DeleteParameters>
            <asp:Parameter Name="EmployeeId" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="Name" Type="String" />
            <asp:Parameter Name="Gender" Type="String" />
            <asp:Parameter Name="City" Type="String" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="Name" Type="String" />
            <asp:Parameter Name="Gender" Type="String" />
            <asp:Parameter Name="City" Type="String" />
            <asp:Parameter Name="EmployeeId" Type="Int32" />
        </UpdateParameters>
    </asp:SqlDataSource>
    </div> --%>

</asp:Content>
