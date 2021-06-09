
Public Class Form1
    Dim abrir As DialogResult
    Dim StrBufferOut As String
    Dim StrBufferIn As String
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Me.Size = New Size(width:=992, height:=598)
        My.Settings.Link2 = Application.StartupPath & "Juegos_listbox.txt"
        My.Settings.Link3 = Application.StartupPath & "Urls_listbox.txt"
        My.Settings.Link4 = Application.StartupPath & "Imagenes_listbox.txt"
        cboPuertos.Visible = False
        Label1.Text = My.Settings.Puertos
        CheckBox9.Parent = Me
        CheckBox9.BackColor = Color.Transparent
        Label1.Parent = Me
        Label1.BackColor = Color.Transparent
        Label2.Parent = Me
        Label2.BackColor = Color.Transparent
        Label4.Parent = Me
        Label4.BackColor = Color.Transparent
        Label6.Parent = Me
        Label6.BackColor = Color.Transparent
        Label7.Parent = Me
        Label7.BackColor = Color.Transparent
        Label8.Parent = Me
        Label8.BackColor = Color.Transparent
        Label9.Parent = Me
        Label9.BackColor = Color.Transparent
        Sumame_esta()
        Conectar()
        Enviar_Dato2()
        Try
            Dim sr As New System.IO.StreamReader(Application.StartupPath & "Juegos_listbox.txt")
            While Not sr.EndOfStream
                ListBox1.Items.Add(sr.ReadLine())
            End While
            sr.Close()
        Catch ex As Exception
            Dim sw As New System.IO.StreamWriter(My.Settings.Link2)
            For Each item In ListBox1.Items
                sw.WriteLine(item.ToString())
            Next
            sw.Close()
        End Try
        Try
            Dim sr As New System.IO.StreamReader(Application.StartupPath & "Urls_listbox.txt")
            While Not sr.EndOfStream
                ListBox3.Items.Add(sr.ReadLine())
            End While
            sr.Close()
        Catch ex As Exception
            Dim sw As New System.IO.StreamWriter(My.Settings.Link3)
            For Each item In ListBox3.Items
                sw.WriteLine(item.ToString())
            Next
            sw.Close()
        End Try
        Try
            Dim sr As New System.IO.StreamReader(Application.StartupPath & "Imagenes_listbox.txt")
            While Not sr.EndOfStream
                ListBox4.Items.Add(sr.ReadLine())
            End While
            sr.Close()
        Catch ex As Exception
            Dim sw As New System.IO.StreamWriter(My.Settings.Link4)
            For Each item In ListBox4.Items
                sw.WriteLine(item.ToString())
            Next
            sw.Close()
        End Try
    End Sub

    Private Sub Button7_Click_1(sender As Object, e As EventArgs) Handles Button7.Click
        ListBox3.Items.Remove(ListBox3.SelectedItem)
        ListBox1.Items.Remove(ListBox1.SelectedItem)
        ListBox4.Items.Remove(ListBox4.SelectedItem)
        Sumame_esta()
        Dim sw As New System.IO.StreamWriter(My.Settings.Link2)
        For Each item In ListBox1.Items
            sw.WriteLine(item.ToString())
        Next
        sw.Close()
        Dim sw1 As New System.IO.StreamWriter(My.Settings.Link3)
        For Each item In ListBox3.Items
            sw1.WriteLine(item.ToString())
        Next
        sw1.Close()
        Dim sw2 As New System.IO.StreamWriter(My.Settings.Link4)
        For Each item In ListBox4.Items
            sw2.WriteLine(item.ToString())
        Next
        sw2.Close()

    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Dim stRuta As String = ""
        Dim openFD As New OpenFileDialog()
        With openFD
            .Title = "Abreme"
            .Filter = "Archivos Text (*.Lnk*.lnk)|*.Lnk; *lnk|Todos los archivos (*.*)|*.*"
            .Multiselect = False
            .InitialDirectory = My.Computer.FileSystem.SpecialDirectories.Desktop
            'Try
            If .ShowDialog = Windows.Forms.DialogResult.OK Then
                ListBox1.Items.Add(openFD.SafeFileName)
                ListBox3.Items.Add(openFD.FileName)
                Dim sw As New System.IO.StreamWriter(My.Settings.Link2)
                For Each item In ListBox1.Items
                    sw.WriteLine(item.ToString())
                Next
                sw.Close()
                Dim sw1 As New System.IO.StreamWriter(My.Settings.Link3)
                For Each item In ListBox3.Items
                    sw1.WriteLine(item.ToString())
                Next
                sw1.Close()
                abrir = MessageBox.Show("Deseas poner un icono para la app?", "Imagen", MessageBoxButtons.YesNo)
                If abrir = DialogResult.No Then
                    ListBox4.Items.Add("No tiene imagen")
                    Dim sw2 As New System.IO.StreamWriter(My.Settings.Link4)
                    For Each item In ListBox4.Items
                        sw2.WriteLine(item.ToString())
                    Next
                    sw2.Close()
                End If
                If abrir = DialogResult.Yes Then
                    abreme_esta()
                End If
            End If
            'Catch ex As Exception
            '   MsgBox("La jodiste")
            'End Try
        End With
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If My.Settings.Con = "A" Then
            Enviar_Dato()
        ElseIf My.Settings.Con = "P" Then
            Enviar_Dato2()
        End If
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim stRuta As String = ""
        Dim openFD As New OpenFileDialog()
        With openFD
            .Title = "Abreme"
            .Filter = "Archivos Text (*.Lnk*.lnk)|*.Lnk; *lnk|Todos los archivos (*.*)|*.*"
            .Multiselect = False
            .InitialDirectory = My.Computer.FileSystem.SpecialDirectories.Desktop
            'Try
            If .ShowDialog = Windows.Forms.DialogResult.OK Then
                ListBox1.Items.Insert(My.Settings.num1 + 1, openFD.SafeFileName)
                ListBox3.Items.Insert(My.Settings.num1 + 1, openFD.FileName)
                Dim sw As New System.IO.StreamWriter(My.Settings.Link2)
                For Each item In ListBox1.Items
                    sw.WriteLine(item.ToString())
                Next
                sw.Close()
                Dim sw1 As New System.IO.StreamWriter(My.Settings.Link3)
                For Each item In ListBox3.Items
                    sw1.WriteLine(item.ToString())
                Next
                sw1.Close()
                abrir = MessageBox.Show("Deseas poner un icono para la app?", "Imagen", MessageBoxButtons.YesNo)
                If abrir = DialogResult.No Then
                    ListBox4.Items.Add("No tiene imagen")
                    Dim sw2 As New System.IO.StreamWriter(My.Settings.Link4)
                    For Each item In ListBox4.Items
                        sw2.WriteLine(item.ToString())
                    Next
                    sw2.Close()
                End If
                If abrir = DialogResult.Yes Then
                    With openFD
                        .Title = "Subir Imagen"
                        .Filter = "Archivos Ico (*.Ico*.ico)|*.Ico; *ico|Archivos Png (*.Png*.png)|*.Png; *png|Todos los archivos (*.*)|*.*"
                        .Multiselect = False
                        .InitialDirectory = My.Computer.FileSystem.SpecialDirectories.Desktop
                        ''Try
                        If .ShowDialog = Windows.Forms.DialogResult.OK Then
                            System.IO.File.Delete(Application.StartupPath & "\Imagenes\" & openFD.SafeFileName)
                            System.IO.File.Copy(openFD.FileName, Application.StartupPath & "\Imagenes\" & openFD.SafeFileName)
                            Dim indices As Double
                            indices = My.Settings.num1 + 1
                            ListBox4.Items.Insert(indices, Application.StartupPath & "\Imagenes\" & openFD.SafeFileName)
                            Dim sw3 As New System.IO.StreamWriter(My.Settings.Link4)
                            For Each item In ListBox4.Items
                                sw3.WriteLine(item.ToString())
                            Next
                            sw3.Close()
                            Sumame_esta()
                            Return
                        End If
                    End With
                End If
            End If
            'Catch ex As Exception
            '   MsgBox("La jodiste")
            'End Try
        End With
    End Sub

    Sub abreme_esta()
        Dim stRuta As String = ""
        Dim openFD As New OpenFileDialog()
        With openFD
            .Title = "Subir Imagen"
            .Filter = "Archivos Ico (*.Ico*.ico)|*.Ico; *ico|Archivos Png (*.Png*.png)|*.Png; *png|Todos los archivos (*.*)|*.*"
            .Multiselect = False
            .InitialDirectory = My.Computer.FileSystem.SpecialDirectories.Desktop
            ''Try
            If .ShowDialog = Windows.Forms.DialogResult.OK Then
                System.IO.File.Delete(Application.StartupPath & "\Imagenes\" & openFD.SafeFileName)
                If PictureBox1.Image IsNot My.Resources.No_hay_foto Then
                    System.IO.File.Copy(openFD.FileName, Application.StartupPath & "\Imagenes\" & openFD.SafeFileName)
                    ListBox4.Items.Add(Application.StartupPath & "\Imagenes\" & openFD.SafeFileName)
                    PictureBox1.Image = Image.FromFile(ListBox4.Items(My.Settings.num1))
                    PictureBox1.Visible = True
                ElseIf PictureBox2.Image IsNot My.Resources.No_hay_foto Then
                    System.IO.File.Copy(openFD.FileName, Application.StartupPath & "\Imagenes\" & openFD.SafeFileName)
                    ListBox4.Items.Add(Application.StartupPath & "\Imagenes\" & openFD.SafeFileName)
                    PictureBox2.Image = Image.FromFile(ListBox4.Items(My.Settings.num2))
                    PictureBox2.Visible = True
                ElseIf PictureBox3.Image IsNot My.Resources.No_hay_foto Then
                    System.IO.File.Copy(openFD.FileName, Application.StartupPath & "\Imagenes\" & openFD.SafeFileName)
                    ListBox4.Items.Add(Application.StartupPath & "\Imagenes\" & openFD.SafeFileName)
                    PictureBox3.Image = Image.FromFile(ListBox4.Items(My.Settings.num3))
                    PictureBox3.Visible = True
                End If
                Dim sw3 As New System.IO.StreamWriter(My.Settings.Link4)
                For Each item In ListBox4.Items
                    sw3.WriteLine(item.ToString())
                Next
                sw3.Close()
                Sumame_esta()
                Return
            End If
            ''Catch ex As Exception
            Dim sw4 As New System.IO.StreamWriter(My.Settings.Link4)
            For Each item In ListBox4.Items
                sw4.WriteLine(item.ToString())
            Next
            sw4.Close()
            ListBox4.Items.Add("No tiene imagen")
            Return
            ''End Try
        End With
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Revisar()
        ''For i = 0 To ListBox2.Items.Count - 1
        ''If ListBox2.Items(i).ToString = LabelHora.Text Then

        ''End If
        ''Exit For
        ''Next i
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs)
        Enviar_Dato2()
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        Form2.ShowDialog()
    End Sub

    Private Sub cboPuertos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboPuertos.SelectedIndexChanged
        Conectar()
        My.Settings.Puertos = cboPuertos.SelectedItem
        Saves()
        Label1.Text = My.Settings.Puertos
        Enviar_Dato2()
    End Sub

    Private Sub CheckBox9_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox9.CheckedChanged
        If CheckBox9.Checked = True Then
            Determinar()
        Else
            cboPuertos.Visible = False
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Form3.Show()
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
        Sumame_esta()
    End Sub

    Sub Determinar()
        cboPuertos.Items.Clear()
        cboPuertos.Visible = True
        For Each PuertoDisponible As String In My.Computer.Ports.SerialPortNames
            cboPuertos.Items.Add(PuertoDisponible)
        Next
        If cboPuertos.Items.Count > 0 Then
            cboPuertos.Text = cboPuertos.Items(0)
        Else
            MessageBox.Show("Ningun Puerto Encontrado")
            cboPuertos.Items.Clear()
        End If
    End Sub

    Sub Conectar()
        StrBufferOut = ""
        StrBufferIn = ""
        Try
            Label2.Text = "Conectar"
            SerialPort1.PortName = Label1.Text
            SerialPort1.Open()
        Catch ex As Exception
            Label2.Text = "Desconectar"
        End Try

    End Sub

    Sub Enviar_Dato()
        Try
            StrBufferIn = SerialPort1.ReadExisting
            SerialPort1.DiscardOutBuffer()
            StrBufferOut = "P"
            SerialPort1.Write(StrBufferOut)
            My.Settings.Con = "P"

        Catch ex As Exception
        End Try
    End Sub

    Sub Enviar_Dato2()
        Try
            StrBufferIn = SerialPort1.ReadExisting
            SerialPort1.DiscardOutBuffer()
            StrBufferOut = "A"
            SerialPort1.Write(StrBufferOut)
            My.Settings.Con = "A"

        Catch ex As Exception
        End Try
    End Sub

    Sub Revisar()
        Try
            StrBufferIn = SerialPort1.ReadExisting
            Label2.Text = "Conectar"
        Catch ex As Exception
            Label2.Text = "Desconectar"
        End Try
        If Label2.Text = "Desconectar" Then
            Try
                Label2.Text = "Conectar"
                SerialPort1.PortName = Label1.Text
                SerialPort1.Open()
            Catch ex As Exception
            End Try
        End If
        If StrBufferIn <> "" Then
            If StrBufferIn = 9 Then
                'ListBox2.Items.Add("Siiii!")
            End If
            StrBufferIn = ""
            SerialPort1.DiscardInBuffer()
        End If
    End Sub

    Sub Sumame_esta()
        Try
            ListBox1.SelectedItem = My.Settings.num1
            ListBox1.SelectedIndex = My.Settings.num1
            My.Settings.Abrir = ListBox1.SelectedIndex
            ListBox3.SelectedIndex = My.Settings.Abrir
            My.Settings.Abrir2 = ListBox3.SelectedItem
            ListBox4.SelectedIndex = My.Settings.num1
            Saves()
        Catch ex As Exception
        End Try

        For Each item In ListBox1.Items
            Try
                Label4.Text = ListBox1.Items(My.Settings.num1).ToString
                PictureBox1.Image = Image.FromFile(ListBox4.Items(My.Settings.num1))
                Saves()
            Catch ex As Exception
                Label4.Text = "No hay nada"
                PictureBox1.Image = My.Resources.No_hay_foto
            End Try
            Try
                Label6.Text = ListBox1.Items(My.Settings.num2).ToString
                PictureBox2.Image = Image.FromFile(ListBox4.Items(My.Settings.num2))
                Saves()
            Catch ex As Exception
                Label6.Text = "No hay nada"
                PictureBox2.Image = My.Resources.No_hay_foto
            End Try
            Try
                Label7.Text = ListBox1.Items(My.Settings.num3).ToString
                PictureBox3.Image = Image.FromFile(ListBox4.Items(My.Settings.num3))
                Saves()
            Catch ex As Exception
                Label7.Text = "No hay nada"
                PictureBox3.Image = My.Resources.No_hay_foto
            End Try
            Try
                Label8.Text = ListBox1.Items(My.Settings.num4).ToString
                PictureBox4.Image = Image.FromFile(ListBox4.Items(My.Settings.num4))
                Saves()
            Catch ex As Exception
                Label8.Text = "No hay nada"
                PictureBox4.Image = My.Resources.No_hay_foto
            End Try
            Try
                Label9.Text = ListBox1.Items(My.Settings.num5).ToString
                PictureBox5.Image = Image.FromFile(ListBox4.Items(My.Settings.num5))
                Saves()
            Catch ex As Exception
                Label9.Text = "No hay nada"
                PictureBox5.Image = My.Resources.No_hay_foto
            End Try
        Next
        Saves()
        Return

    End Sub

    Private Sub Saves()
        My.Settings.Save()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim stRuta As String = ""
        Dim openFD As New OpenFileDialog()
        With openFD
            .Title = "Remplazar"
            .Filter = "Archivos Text (*.Lnk*.lnk)|*.Lnk; *lnk|Todos los archivos (*.*)|*.*"
            .Multiselect = False
            .InitialDirectory = My.Computer.FileSystem.SpecialDirectories.Desktop
            ''Try
            If .ShowDialog = Windows.Forms.DialogResult.OK Then
                Dim indices1 = ListBox1.SelectedIndex
                Dim indices3 = ListBox3.SelectedIndex
                Dim indices4 = ListBox4.SelectedIndex
                ListBox1.Items.RemoveAt(indices1)
                ListBox1.Items.Insert(indices1, openFD.SafeFileName)
                ListBox3.Items.RemoveAt(indices3)
                ListBox3.Items.Insert(indices3, openFD.FileName)
                Dim sw As New System.IO.StreamWriter(My.Settings.Link2)
                For Each item In ListBox1.Items
                    sw.WriteLine(item.ToString())
                Next
                sw.Close()
                Dim sw1 As New System.IO.StreamWriter(My.Settings.Link3)
                For Each item In ListBox3.Items
                    sw1.WriteLine(item.ToString())
                Next
                sw1.Close()

                abrir = MessageBox.Show("Deseas poner un icono para la app?", "Imagen", MessageBoxButtons.YesNo)
                If abrir = DialogResult.No Then
                    ListBox4.Items.Add("No tiene imagen")
                    Dim sw2 As New System.IO.StreamWriter(My.Settings.Link4)
                    For Each item In ListBox4.Items
                        sw2.WriteLine(item.ToString())
                    Next
                    sw2.Close()
                End If
                If abrir = DialogResult.Yes Then
                    Dim stRuta2 As String = ""
                    Dim openFD2 As New OpenFileDialog()
                    With openFD2
                        .Title = "Subir Imagen"
                        .Filter = "Archivos Ico (*.Ico*.ico)|*.Ico; *ico|Archivos Png (*.Png*.png)|*.Png; *png|Todos los archivos (*.*)|*.*"
                        .Multiselect = False
                        .InitialDirectory = My.Computer.FileSystem.SpecialDirectories.Desktop
                        ''Try
                        If .ShowDialog = Windows.Forms.DialogResult.OK Then
                            System.IO.File.Copy(openFD2.FileName, Application.StartupPath & "\Imagenes\" & openFD2.SafeFileName)
                            ListBox4.Items.RemoveAt(indices4)
                            ListBox4.Items.Insert(indices4, Application.StartupPath & "\Imagenes\" & openFD2.SafeFileName)
                            Dim sw3 As New System.IO.StreamWriter(My.Settings.Link4)
                            For Each item In ListBox4.Items
                                sw3.WriteLine(item.ToString())
                            Next
                            sw3.Close()
                            Sumame_esta()
                            Return
                        End If
                    End With
                End If
                Sumame_esta()
                Return
            End If
        End With
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Process.Start(ListBox3.Items(My.Settings.num1).ToString())
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Process.Start(ListBox3.Items(My.Settings.num2).ToString())
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        Process.Start(ListBox3.Items(My.Settings.num3).ToString())
    End Sub

    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
        Process.Start(ListBox3.Items(My.Settings.num4).ToString())
    End Sub

    Private Sub PictureBox5_Click(sender As Object, e As EventArgs) Handles PictureBox5.Click
        Process.Start(ListBox3.Items(My.Settings.num5).ToString())
    End Sub

    Private Sub Form1_MouseWheel(sender As Object, e As MouseEventArgs) Handles Me.MouseWheel
        If e.Delta = 120 Then
            My.Settings.num1 = My.Settings.num1 + 1
            My.Settings.num2 = My.Settings.num2 + 1
            My.Settings.num3 = My.Settings.num3 + 1
            My.Settings.num4 = My.Settings.num4 + 1
            My.Settings.num5 = My.Settings.num5 + 1
            Sumame_esta()

            Saves()
        ElseIf e.Delta = -120 Then
            If (My.Settings.num1 > 0) Then

                My.Settings.num1 = My.Settings.num1 - 1
                My.Settings.num2 = My.Settings.num2 - 1
                My.Settings.num3 = My.Settings.num3 - 1
                My.Settings.num4 = My.Settings.num4 - 1
                My.Settings.num5 = My.Settings.num5 - 1
                Sumame_esta()
                Saves()
            End If
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim stRuta As String = ""
        Dim openFD As New OpenFileDialog()
        With openFD
            .Title = "Subir Imagen"
            .Filter = "Archivos Ico (*.Ico*.ico)|*.Ico; *ico|Archivos Png (*.Png*.png)|*.Png; *png|Todos los archivos (*.*)|*.*"
            .Multiselect = False
            .InitialDirectory = My.Computer.FileSystem.SpecialDirectories.Desktop
            ''Try
            If .ShowDialog = Windows.Forms.DialogResult.OK Then
                System.IO.File.Copy(openFD.FileName, Application.StartupPath & "\Imagenes\" & openFD.SafeFileName)
                Dim indices As Double
                indices = ListBox4.SelectedIndex
                ListBox4.Items.RemoveAt(indices)
                ListBox4.Items.Insert(indices, Application.StartupPath & "\Imagenes\" & openFD.SafeFileName)
                Dim sw3 As New System.IO.StreamWriter(My.Settings.Link4)
                For Each item In ListBox4.Items
                    sw3.WriteLine(item.ToString())
                Next
                sw3.Close()
                Sumame_esta()
                Return
            End If
        End With
    End Sub

    Private Sub Form1_Click(sender As Object, e As EventArgs) Handles Me.Click
        Sumame_esta()
    End Sub

End Class