Imports System
Imports System.Drawing

Public Class Login
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents lblPassword As System.Windows.Forms.Label
    Friend WithEvents lblUsername As System.Windows.Forms.Label
    Friend WithEvents lblAuthentication As System.Windows.Forms.Label
    Friend WithEvents lblServer As System.Windows.Forms.Label
    Friend WithEvents txtServer As System.Windows.Forms.TextBox
    Friend WithEvents btnConnect As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
    Friend WithEvents txtUsername As System.Windows.Forms.TextBox
    Friend WithEvents cboAuthenticationMethod As System.Windows.Forms.ComboBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.lblPassword = New System.Windows.Forms.Label
        Me.lblUsername = New System.Windows.Forms.Label
        Me.lblAuthentication = New System.Windows.Forms.Label
        Me.lblServer = New System.Windows.Forms.Label
        Me.txtServer = New System.Windows.Forms.TextBox
        Me.btnConnect = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.txtPassword = New System.Windows.Forms.TextBox
        Me.txtUsername = New System.Windows.Forms.TextBox
        Me.cboAuthenticationMethod = New System.Windows.Forms.ComboBox
        Me.SuspendLayout()
        '
        'lblPassword
        '
        Me.lblPassword.AutoSize = True
        Me.lblPassword.Location = New System.Drawing.Point(36, 93)
        Me.lblPassword.Name = "lblPassword"
        Me.lblPassword.Size = New System.Drawing.Size(57, 16)
        Me.lblPassword.TabIndex = 19
        Me.lblPassword.Text = "Password:"
        '
        'lblUsername
        '
        Me.lblUsername.AutoSize = True
        Me.lblUsername.Location = New System.Drawing.Point(36, 69)
        Me.lblUsername.Name = "lblUsername"
        Me.lblUsername.Size = New System.Drawing.Size(60, 16)
        Me.lblUsername.TabIndex = 18
        Me.lblUsername.Text = "Username:"
        '
        'lblAuthentication
        '
        Me.lblAuthentication.AutoSize = True
        Me.lblAuthentication.Location = New System.Drawing.Point(20, 45)
        Me.lblAuthentication.Name = "lblAuthentication"
        Me.lblAuthentication.Size = New System.Drawing.Size(79, 16)
        Me.lblAuthentication.TabIndex = 17
        Me.lblAuthentication.Text = "Authentication:"
        '
        'lblServer
        '
        Me.lblServer.AutoSize = True
        Me.lblServer.Location = New System.Drawing.Point(20, 21)
        Me.lblServer.Name = "lblServer"
        Me.lblServer.Size = New System.Drawing.Size(88, 16)
        Me.lblServer.TabIndex = 16
        Me.lblServer.Text = "Server Name/IP:"
        '
        'txtServer
        '
        Me.txtServer.Location = New System.Drawing.Point(156, 21)
        Me.txtServer.Name = "txtServer"
        Me.txtServer.Size = New System.Drawing.Size(248, 20)
        Me.txtServer.TabIndex = 10
        Me.txtServer.Text = "(local)"
        '
        'btnConnect
        '
        Me.btnConnect.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnConnect.Location = New System.Drawing.Point(244, 149)
        Me.btnConnect.Name = "btnConnect"
        Me.btnConnect.TabIndex = 14
        Me.btnConnect.Text = "Connect"
        '
        'btnCancel
        '
        Me.btnCancel.CausesValidation = False
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(332, 149)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.TabIndex = 15
        Me.btnCancel.Text = "Cancel"
        '
        'txtPassword
        '
        Me.txtPassword.Location = New System.Drawing.Point(172, 93)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.Size = New System.Drawing.Size(232, 20)
        Me.txtPassword.TabIndex = 13
        Me.txtPassword.Text = ""
        '
        'txtUsername
        '
        Me.txtUsername.Location = New System.Drawing.Point(172, 69)
        Me.txtUsername.Name = "txtUsername"
        Me.txtUsername.Size = New System.Drawing.Size(232, 20)
        Me.txtUsername.TabIndex = 12
        Me.txtUsername.Text = ""
        '
        'cboAuthenticationMethod
        '
        Me.cboAuthenticationMethod.Items.AddRange(New Object() {"Windows Authentication", "SQL Server Authentication"})
        Me.cboAuthenticationMethod.Location = New System.Drawing.Point(156, 45)
        Me.cboAuthenticationMethod.Name = "cboAuthenticationMethod"
        Me.cboAuthenticationMethod.Size = New System.Drawing.Size(248, 21)
        Me.cboAuthenticationMethod.TabIndex = 11
        '
        'Login
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(426, 192)
        Me.ControlBox = False
        Me.Controls.Add(Me.lblPassword)
        Me.Controls.Add(Me.lblUsername)
        Me.Controls.Add(Me.lblAuthentication)
        Me.Controls.Add(Me.lblServer)
        Me.Controls.Add(Me.txtServer)
        Me.Controls.Add(Me.btnConnect)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.txtPassword)
        Me.Controls.Add(Me.txtUsername)
        Me.Controls.Add(Me.cboAuthenticationMethod)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Login"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Login"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub Login_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim line As line = New line
        Dim buffer As Integer = 10

        line.X_Left = buffer
        line.Y_Left = btnConnect.Top - buffer
        line.X_Right = Me.Width - buffer * 2
        line.Y_Right = line.Y_Left
        line.Color = Color.Black

        Me.Controls.Add(line)

        ' Select the first item in the list
        Me.cboAuthenticationMethod.SelectedIndex = 0
        Me.lblUsername.Enabled = False
        Me.lblPassword.Enabled = False
        Me.txtUsername.Enabled = False
        Me.txtPassword.Enabled = False

    End Sub

    Public _username As String = String.Empty
    Public _password As String = String.Empty
    Public _useIntegratedSecurity As Boolean = True
    Public _server As String = String.Empty

    Private Sub btnConnect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConnect.Click
        _server = txtServer.Text

        If Me.cboAuthenticationMethod.SelectedIndex = 0 Then
            _useIntegratedSecurity = True
            _username = String.Empty
            _password = String.Empty
        Else
            _useIntegratedSecurity = False
            _username = txtUsername.Text
            _password = txtPassword.Text
        End If

    End Sub

    Private Sub cboAuthenticationMethod_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboAuthenticationMethod.SelectedIndexChanged
        Me.lblUsername.Enabled = (Me.cboAuthenticationMethod.SelectedIndex = 1)
        Me.lblPassword.Enabled = (Me.cboAuthenticationMethod.SelectedIndex = 1)
        Me.txtUsername.Enabled = (Me.cboAuthenticationMethod.SelectedIndex = 1)
        Me.txtPassword.Enabled = (Me.cboAuthenticationMethod.SelectedIndex = 1)
    End Sub
End Class

Public Class Line
    Inherits System.Windows.Forms.Control
    Public Sub New()
    End Sub

#Region "Public Properties"
    Private _color As System.Drawing.Color = Color.Black
    Public Property Color() As System.Drawing.Color
        Get
            Return _color
        End Get
        Set(ByVal Value As System.Drawing.Color)
            _color = value
        End Set
    End Property

    Private xLeft As Integer = 0
    Public Property X_Left() As Integer
        Get
            Return xLeft
        End Get
        Set(ByVal Value As Integer)
            xLeft = value
        End Set
    End Property

    Private yLeft As Integer = 0
    Public Property Y_Left() As Integer
        Get
            Return yLeft
        End Get
        Set(ByVal Value As Integer)
            yLeft = value
        End Set
    End Property

    Private xRight As Integer = 0
    Public Property X_Right() As Integer
        Get
            Return xRight
        End Get
        Set(ByVal Value As Integer)
            xRight = value
            If xLeft <= xRight Then
                Width = xRight - xLeft
            Else
                Width = xLeft - xRight
            End If
        End Set
    End Property

    Private yRight As Integer = 0
    Public Property Y_Right() As Integer
        Get
            Return yRight
        End Get
        Set(ByVal Value As Integer)
            yRight = value
            If yLeft <= yRight Then
                Height = yRight - yLeft
            Else
                Height = yLeft - yRight
            End If
        End Set
    End Property
#End Region

#Region "Protected Methods"
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        MyBase.Dispose(disposing)
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        If xLeft <= xRight Then
            Left = xLeft
        Else
            Left = xRight
        End If
        If yLeft <= yRight Then
            Top = yLeft
        Else
            Top = yRight
        End If
        Dim brush As SolidBrush = New SolidBrush(Me.Parent.BackColor)
        e.Graphics.FillRectangle(brush, 0, 0, Me.Width, Me.Height)
        Dim pen As pen = New pen(_color)
        If xLeft < xRight AndAlso yLeft < yRight Then
            e.Graphics.DrawLine(pen, 0, 0, Me.Width, Me.Height)
        ElseIf xLeft > xRight AndAlso yLeft < yRight Then
            e.Graphics.DrawLine(pen, Me.Width, 0, 0, Me.Height)
        ElseIf xLeft > xRight AndAlso yLeft > yRight Then
            e.Graphics.DrawLine(pen, Me.Width, Me.Height, 0, 0)
        ElseIf xLeft < xRight AndAlso yLeft > yRight Then
            e.Graphics.DrawLine(pen, 0, Me.Height, Me.Width, 0)
        End If
    End Sub
#End Region
End Class
