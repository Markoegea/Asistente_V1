Public Class Form2
    Dim jas = New TextBox
    Dim jas2 = New Label
    Dim cont = 1
    Dim tops = 3
    Dim lef = 7
    Dim Dato1 As Double
    Dim Dato2 As Double
    Dim Ope As Double
    Dim Res As Double
    Dim Cadena As Double
    Dim MEM As String


    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles M.Click

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles MASOMENOS.Click
        If PANTALLA1.Text <> "" Then
            PANTALLA1.Text = PANTALLA1.Text * -1
        End If

    End Sub

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        jas2.Width = Convert.ToInt16(200)
        jas2.Height = Convert.ToInt16(202)
        jas2.Top = Convert.ToInt16(tops)
        jas2.Left = Convert.ToInt16(lef)
        Panel1.Controls.Add(jas2)
        jas2.Name = "LABEL" & cont
        jas2.Text = "Funciona!!!"
        cont = cont - 1
        tops = tops - 5
        lef = lef - 7


    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Label3.Text = "cont es " & cont
        Label4.Text = "tops es " & tops
        Label5.Text = "lefs es " & lef
        If CheckBox1.Checked = True Then
            tops = tops + 1
            lef = lef - 7
            jas2.Width = Convert.ToInt16(200)
            jas2.Height = Convert.ToInt16(202)
            jas2.Top = Convert.ToInt16(tops)
            jas2.Left = Convert.ToInt16(lef)
        End If

    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub MS_Click(sender As Object, e As EventArgs) Handles MS.Click
        MEM = PANTALLA1.Text
        M.Visible = True
    End Sub

    Private Sub Salir_Click(sender As Object, e As EventArgs) Handles Salir.Click
        Me.Close()
    End Sub

    Private Sub UNO_Click(sender As Object, e As EventArgs) Handles UNO.Click
        PANTALLA1.Text = PANTALLA1.Text & "1"
    End Sub

    Private Sub DOS_Click(sender As Object, e As EventArgs) Handles DOS.Click
        PANTALLA1.Text = PANTALLA1.Text & "2"
    End Sub

    Private Sub TRES_Click(sender As Object, e As EventArgs) Handles TRES.Click
        PANTALLA1.Text = PANTALLA1.Text & "3"
    End Sub

    Private Sub CUATRO_Click(sender As Object, e As EventArgs) Handles CUATRO.Click
        PANTALLA1.Text = PANTALLA1.Text & "4"
    End Sub

    Private Sub CINCO_Click(sender As Object, e As EventArgs) Handles CINCO.Click
        PANTALLA1.Text = PANTALLA1.Text & "5"
    End Sub

    Private Sub SEIS_Click(sender As Object, e As EventArgs) Handles SEIS.Click
        PANTALLA1.Text = PANTALLA1.Text & "6"
    End Sub

    Private Sub SIETE_Click(sender As Object, e As EventArgs) Handles SIETE.Click
        PANTALLA1.Text = PANTALLA1.Text & "7"
    End Sub

    Private Sub OCHO_Click(sender As Object, e As EventArgs) Handles OCHO.Click
        PANTALLA1.Text = PANTALLA1.Text & "8"
    End Sub

    Private Sub NUEVE_Click(sender As Object, e As EventArgs) Handles NUEVE.Click
        PANTALLA1.Text = PANTALLA1.Text & "9"
    End Sub

    Private Sub CERO_Click(sender As Object, e As EventArgs) Handles CERO.Click
        PANTALLA1.Text = PANTALLA1.Text & "0"
    End Sub

    Private Sub PUNTO_Click(sender As Object, e As EventArgs) Handles PUNTO.Click
        Try
            If PANTALLA1.Text.IndexOf(".") > 0 Then
                Beep()
            ElseIf Not PANTALLA1.Text = "." Then
                PANTALLA1.Text = PANTALLA1.Text & "."
            Else
                PANTALLA1.Text = "0."
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub MAS_Click(sender As Object, e As EventArgs) Handles MAS.Click

        Dato2 = (PANTALLA1.Text)
        Norepetir()

        Ope = 1
        Dato1 = (PANTALLA1.Text)
        PANTALLA1.Clear()
                PANTALLA2.Text = Dato1 & "+"

    End Sub

    Private Sub MENOS_Click(sender As Object, e As EventArgs) Handles MENOS.Click
        Dato2 = (PANTALLA1.Text)
        Norepetir()
        Ope = 2
        Dato1 = (PANTALLA1.Text)
        PANTALLA1.Clear()
        PANTALLA2.Text = Dato1 & "-"
    End Sub

    Private Sub POR_Click(sender As Object, e As EventArgs) Handles POR.Click
        Dato2 = (PANTALLA1.Text)
        Norepetir()
        Ope = 3
        Dato1 = (PANTALLA1.Text)
        PANTALLA1.Clear()
        PANTALLA2.Text = Dato1 & "*"
    End Sub

    Private Sub DIVIDIR_Click(sender As Object, e As EventArgs) Handles DIVIDIR.Click
        Dato2 = (PANTALLA1.Text)
        Norepetir()
        Ope = 4
        Dato1 = (PANTALLA1.Text)
        PANTALLA1.Clear()
        PANTALLA2.Text = Dato1 & "/"
    End Sub

    Private Sub IGUAL_Click(sender As Object, e As EventArgs) Handles IGUAL.Click
        Dato2 = PANTALLA1.Text
        Norepetir()
    End Sub

    Private Sub BORRAR_Click(sender As Object, e As EventArgs) Handles BORRAR.Click
        If PANTALLA1.Text <> "" Then
            Cadena = PANTALLA1.Text.Length
            PANTALLA1.Text = Mid(PANTALLA1.Text, 1, Cadena - 1)
        End If

    End Sub

    Private Sub BORRARTODO_Click(sender As Object, e As EventArgs) Handles BORRARTODO.Click
        PANTALLA1.Text = ""
        PANTALLA2.Text = ""
        Dato1 = 0
        Dato2 = 0
        Res = 0
    End Sub

    Private Sub RECIPROCO_Click(sender As Object, e As EventArgs) Handles RECIPROCO.Click


        If Dato1 = "0" Then
            PANTALLA1.Text = 1 / PANTALLA1.Text
            Dato1 = PANTALLA1.Text

        Else
            PANTALLA1.Text = 1 / PANTALLA1.Text
            Dato2 = PANTALLA1.Text


        End If
        Norepetir()

    End Sub

    Private Sub CUADRADO_Click(sender As Object, e As EventArgs) Handles CUADRADO.Click
        If Dato1 = "0" Then
            PANTALLA1.Text = PANTALLA1.Text ^ 2
            Dato1 = PANTALLA1.Text
            PANTALLA2.Text = PANTALLA1.Text

        Else

            PANTALLA1.Text = ((PANTALLA1.Text) ^ (2))
            Dato2 = PANTALLA1.Text

        End If
        Norepetir()



    End Sub

    Private Sub RAIZ_Click(sender As Object, e As EventArgs) Handles RAIZ.Click
        If Dato1 = "0" Then
            PANTALLA1.Text = PANTALLA1.Text ^ (1 / 2)
            Dato1 = PANTALLA1.Text
            PANTALLA2.Text = PANTALLA1.Text

        Else

            PANTALLA1.Text = ((PANTALLA1.Text) ^ (1 / 2))
            Dato2 = PANTALLA1.Text

        End If
        Norepetir()
    End Sub
    Public Sub Norepetir()
        If Ope = 1 Then
            Res = Dato1 + Dato2
            PANTALLA1.Text = Res
            PANTALLA2.Text = PANTALLA2.Text & Dato2
            Ope = 0
        ElseIf Ope = 2 Then
            Res = Dato1 - Dato2
            PANTALLA1.Text = Res
            PANTALLA2.Text = PANTALLA2.Text & Dato2
            Ope = 0
        ElseIf Ope = 3 Then
            Res = Dato1 * Dato2
            PANTALLA1.Text = Res
            PANTALLA2.Text = PANTALLA2.Text & Dato2
            Ope = 0
        ElseIf Ope = 4 Then
            Res = Dato1 / Dato2
            PANTALLA1.Text = Res
            PANTALLA2.Text = PANTALLA2.Text & Dato2
            Ope = 0
        ElseIf Ope = 5 Then
            Res = Dato1 ^ Dato2
            PANTALLA1.Text = Res
            PANTALLA2.Text = PANTALLA2.Text & Dato2
            Ope = 0
        End If
    End Sub

    Private Sub PROCENTAJE_Click(sender As Object, e As EventArgs) Handles PROCENTAJE.Click
        Dato2 = PANTALLA1.Text

        Norepetir()
        PANTALLA2.Text = PANTALLA2.Text & "%"
        Res = ((Dato1 * Dato2) / 100)

        PANTALLA1.Text = Res

    End Sub

    Private Sub LOGARITMACION_Click(sender As Object, e As EventArgs) Handles LOGARITMACION.Click
        Try
            If Dato1 = "0" Then
                PANTALLA2.Text = "log(" & PANTALLA1.Text & ")"
                PANTALLA1.Text = Math.Log10(PANTALLA1.Text)
                Dato1 = PANTALLA1.Text


            Else

                PANTALLA1.Text = Math.Log10(PANTALLA1.Text)
                Dato2 = PANTALLA1.Text
                PANTALLA2.Text = PANTALLA2.Text & "log(" & PANTALLA1.Text & ")"
            End If
            Norepetir()


        Catch ex As Exception
            MsgBox("De malas")
            PANTALLA1.Text = ""
            PANTALLA2.Text = ""
        End Try
    End Sub

    Private Sub TANGENTE_Click(sender As Object, e As EventArgs) Handles TANGENTE.Click
        Try
            If Dato1 = "0" Then
                PANTALLA2.Text = "Tan(" & PANTALLA1.Text & ")"
                PANTALLA1.Text = Math.Tan(PANTALLA1.Text)
                Dato1 = PANTALLA1.Text


            Else

                PANTALLA1.Text = Math.Tan(PANTALLA1.Text)
                Dato2 = PANTALLA1.Text
                PANTALLA2.Text = PANTALLA2.Text & "Tan(" & PANTALLA1.Text & ")"
            End If
            Norepetir()


        Catch ex As Exception
            MsgBox("De malas")
            PANTALLA1.Text = ""
            PANTALLA2.Text = ""
        End Try
    End Sub

    Private Sub COSENO_Click(sender As Object, e As EventArgs) Handles COSENO.Click
        Try
            If Dato1 = "0" Then
                PANTALLA2.Text = "Cos(" & PANTALLA1.Text & ")"
                PANTALLA1.Text = Math.Cos(PANTALLA1.Text)
                Dato1 = PANTALLA1.Text


            Else

                PANTALLA1.Text = Math.Cos(PANTALLA1.Text)
                Dato2 = PANTALLA1.Text
                PANTALLA2.Text = PANTALLA2.Text & "Cos" & PANTALLA1.Text & ")"
            End If
            Norepetir()


        Catch ex As Exception
            MsgBox("De malas")
            PANTALLA1.Text = ""
            PANTALLA2.Text = ""
        End Try
    End Sub

    Private Sub SENO_Click(sender As Object, e As EventArgs) Handles SENO.Click
        Try
            If Dato1 = "0" Then
                PANTALLA2.Text = "Sen(" & PANTALLA1.Text & ")"
                PANTALLA1.Text = Math.Sin(PANTALLA1.Text)
                Dato1 = PANTALLA1.Text


            Else

                PANTALLA1.Text = Math.Sin(PANTALLA1.Text)
                Dato2 = PANTALLA1.Text
                PANTALLA2.Text = PANTALLA2.Text & "sen(" & PANTALLA1.Text & ")"
            End If
            Norepetir()


        Catch ex As Exception
            MsgBox("De malas")
            PANTALLA1.Text = ""
            PANTALLA2.Text = ""
        End Try
    End Sub

    Private Sub PI_Click(sender As Object, e As EventArgs) Handles PI.Click
        Try


            PANTALLA1.Text = Math.PI



        Catch ex As Exception
            MsgBox("De malas")
            PANTALLA1.Text = ""
            PANTALLA2.Text = ""
        End Try
    End Sub

    Private Sub EXPONENTE_Click(sender As Object, e As EventArgs) Handles EXPONENTE.Click

        Try


            PANTALLA1.Text = Math.Exp(PANTALLA1.Text)



        Catch ex As Exception
            MsgBox("De malas")
            PANTALLA1.Text = ""
            PANTALLA2.Text = ""
        End Try
    End Sub

    Private Sub DIEZX_Click(sender As Object, e As EventArgs) Handles DIEZX.Click
        Dato1 = 10
        PANTALLA2.Text = "10^" & PANTALLA1.Text
        Dato2 = Val(PANTALLA1.Text)
        PANTALLA1.Text = Dato1 ^ Dato2
    End Sub

    Private Sub ELEVADOA_Click(sender As Object, e As EventArgs) Handles ELEVADOA.Click
        Dato1 = (PANTALLA1.Text)

        Norepetir()
        Ope = 5
        Dato2 = (PANTALLA1.Text)
        PANTALLA1.Clear()
        PANTALLA2.Text = Dato1 & "^"
    End Sub

    Private Sub MR_Click(sender As Object, e As EventArgs) Handles MR.Click
        PANTALLA1.Text = MEM

    End Sub

    Private Sub MC_Click(sender As Object, e As EventArgs) Handles MC.Click
        MEM = ""
        M.Visible = False
    End Sub
End Class