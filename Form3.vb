Public Class Form3
    Dim Num As Integer
    Dim Num2 As Integer
    Dim Num3 As Integer
    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Num = 0
        Me.TopMost = True
        Me.Opacity = 0
        Label1.Visible = False
        Label2.Visible = False
        Label3.Visible = False
        Label4.Visible = False
        Label5.Visible = False
        Label6.Visible = False
        Label7.Visible = False
        Label8.Visible = False
        Label9.Visible = False
        Label10.Visible = False
        Label11.Visible = False
        Label12.Visible = False
        Timer1.Enabled = True
        'PictureBox2.Visible = False
    End Sub

    Private Sub Label12_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If Me.Opacity < 1 Then
            Me.Opacity += 0.05
        ElseIf Me.Opacity = 1 Then

            If Num < 12 Then
                Num += 1
                If Num = 1 Then
                    Label1.Visible = True
                End If
                If Num = 2 Then
                    Label2.Visible = True
                End If
                If Num = 3 Then
                    Label3.Visible = True
                End If
                If Num = 4 Then
                    Label4.Visible = True
                End If
                If Num = 5 Then
                    Label5.Visible = True
                End If
                If Num = 6 Then
                    Label6.Visible = True
                End If
                If Num = 7 Then
                    Label7.Visible = True
                End If
                If Num = 8 Then
                    Label8.Visible = True
                End If
                If Num = 9 Then
                    Label9.Visible = True
                End If
                If Num = 10 Then
                    Label10.Visible = True
                End If
                If Num = 11 Then
                    Label11.Visible = True

                End If
                If Num = 12 Then
                    Label12.Visible = True
                End If
            End If

        End If

    End Sub
    Private Sub Protocolo_1()
        PictureBox2.Visible = True
        Timer2.Enabled = True
        Timer1.Enabled = False
    End Sub
    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
        Protocolo_1()
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click

    End Sub
End Class