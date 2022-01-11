
Public Class Form1
    Dim abrir As DialogResult
    Dim StrBufferOut As String
    Dim StrBufferIn As String
    Dim safeFileName As String
    Dim fileName As String
    Dim indice As String
    Dim numeritoX As Integer
    Dim numeritoY As Integer
    Dim modalidad = "Stand_by"



    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        My.Settings.Link2 = Application.StartupPath & "Juegos_listbox.txt"
        My.Settings.Link3 = Application.StartupPath & "Urls_listbox.txt"
        My.Settings.Link4 = Application.StartupPath & "Imagenes_listbox.txt"
        cboPuertos.Visible = False
        Label1.Text = My.Settings.Puertos
        Label1.Parent = Me
        Label1.BackColor = Color.Transparent
        Label2.Parent = Me
        Label2.BackColor = Color.Transparent
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
        objetoPicture()
    End Sub


    Private Sub Button7_Click_1(sender As Object, e As EventArgs) Handles Button7.Click
        modalidad = "Borrar"
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Dim stRuta As String = ""
        Dim openFD As New OpenFileDialog()
        With openFD
            .Title = "Abreme"
            .Filter = "Archivos Text (*.Lnk*.lnk)|*.Lnk; *lnk|Todos los archivos (*.*)|*.*"
            .Multiselect = False
            .InitialDirectory = My.Computer.FileSystem.SpecialDirectories.Desktop
            If .ShowDialog = Windows.Forms.DialogResult.OK Then
                safeFileName = openFD.SafeFileName
                fileName = openFD.FileName
                abreme_esta()
            End If
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
        objetoButton()
    End Sub

    Sub abreme_esta()
        Dim stRuta As String = ""
        Dim openFD As New OpenFileDialog()
        With openFD
            .Title = "Subir Imagen"
            .Filter = "Archivos Ico (*.Ico*.ico)|*.Ico; *ico|Archivos Png (*.Png*.png)|*.Png; *png|Todos los archivos (*.*)|*.*"
            .Multiselect = False
            .InitialDirectory = My.Computer.FileSystem.SpecialDirectories.Desktop
            If .ShowDialog = Windows.Forms.DialogResult.OK Then
                Try
                    System.IO.File.Copy(openFD.FileName, Application.StartupPath & "\Imagenes\" & openFD.SafeFileName)
                Catch e As Exception
                End Try
                ListBox1.Items.Add(safeFileName)
                ListBox3.Items.Add(fileName)
                ListBox4.Items.Add(Application.StartupPath & "\Imagenes\" & openFD.SafeFileName)
                guardarArchivos()
                objetoPicture()
                Return
            End If
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

    Private Sub Saves()
        My.Settings.Save()
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


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        modalidad = "Reemplazar"
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        modalidad = "CambiarImagen"
    End Sub

    Sub objetoPicture()
        Dim listaElements = ListBox1.Items.Count
        numeritoX = 210
        numeritoY = 35
        For Each items In ListBox1.Items
            indice = ListBox1.Items.IndexOf(items)

            Dim pictureBox As New PictureBox()
            Dim label As New Label()
            Dim button As New Button()
            pictureBox.Image = Image.FromFile(ListBox4.Items(indice))
            pictureBox.Location = New Point(numeritoX, numeritoY)
            pictureBox.Size = New Size(194, 212)
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage
            pictureBox.Name = ListBox3.Items(indice)
            AddHandler pictureBox.Click, AddressOf ElpictureBox_Click


            Label.Location = New Point(numeritoX + 20, (numeritoY + 215))
            label.Size = New Size(165, 95)
            label.ForeColor = Color.FromArgb(255, 255, 128)
            label.Font = New Font("Microsoft Tai Le", 14.25)
            label.TextAlign = ContentAlignment.MiddleCenter
            label.Text = items
            label.Parent = Me
            label.BackColor = Color.Transparent


            Button.Location = New Point(numeritoX - 10, (numeritoY - 6))
            button.Size = New Size(13, 229)
            button.ForeColor = Color.FromArgb(255, 255, 128)
            button.Font = New Font("Microsoft Tai Le", 10)
            button.TextAlign = ContentAlignment.MiddleCenter
            button.Text = ">"
            button.Visible = False
            button.Name = items
            button.FlatStyle = FlatStyle.Popup
            button.Parent = Me
            button.BackColor = Color.Transparent
            AddHandler button.Click, AddressOf Elbutton_Click


            Me.Controls.Add(pictureBox)
            Me.Controls.Add(label)
            Me.Controls.Add(button)

            If numeritoX = 825 Then
                numeritoX = 210
                numeritoY = numeritoY + 310
            Else
                numeritoX = numeritoX + 205
            End If
        Next
    End Sub
    Private Sub ElpictureBox_Click(sender As Object, e As EventArgs)
        Dim pictureBox As PictureBox = DirectCast(sender, PictureBox)
        indice = ListBox3.Items.IndexOf(pictureBox.Name)
        If modalidad = "Stand_by" Then
            Process.Start(pictureBox.Name.ToString())
        ElseIf modalidad = "Reemplazar" Then
            Dim stRuta As String = ""
            Dim openFD As New OpenFileDialog()
            With openFD
                .Title = "Remplazar"
                .Filter = "Archivos Text (*.Lnk*.lnk)|*.Lnk; *lnk|Todos los archivos (*.*)|*.*"
                .Multiselect = False
                .InitialDirectory = My.Computer.FileSystem.SpecialDirectories.Desktop
                If .ShowDialog = Windows.Forms.DialogResult.OK Then
                    ListBox1.Items.RemoveAt(indice)
                    ListBox1.Items.Insert(indice, openFD.SafeFileName)
                    ListBox3.Items.RemoveAt(indice)
                    ListBox3.Items.Insert(indice, openFD.FileName)
                    guardarArchivos()
                    borrarObjeto(e, e)
                End If
            End With
        ElseIf modalidad = "CambiarImagen" Then
            Dim stRuta As String = ""
            Dim openFD As New OpenFileDialog()
            With openFD
                .Title = "Subir Imagen"
                .Filter = "Archivos Ico (*.Ico*.ico)|*.Ico; *ico|Archivos Png (*.Png*.png)|*.Png; *png|Todos los archivos (*.*)|*.*"
                .Multiselect = False
                .InitialDirectory = My.Computer.FileSystem.SpecialDirectories.Desktop
                If .ShowDialog = Windows.Forms.DialogResult.OK Then
                    Try
                        System.IO.File.Copy(openFD.FileName, Application.StartupPath & "\Imagenes\" & openFD.SafeFileName)
                    Catch x As Exception
                    End Try
                    ListBox4.Items.RemoveAt(indice)
                    ListBox4.Items.Insert(indice, Application.StartupPath & "\Imagenes\" & openFD.SafeFileName)
                    guardarArchivos()
                    borrarObjeto(e, e)
                End If
            End With
        ElseIf modalidad = "Borrar" Then
            ListBox3.Items.Remove(ListBox3.Items(indice))
            ListBox1.Items.Remove(ListBox1.Items(indice))
            ListBox4.Items.Remove(ListBox4.Items(indice))
            guardarArchivos()
            borrarObjeto(e, e)
        End If

    End Sub
    Private Sub Elbutton_Click(sender As Object, e As EventArgs)
        Dim button As Button = DirectCast(sender, Button)
        indice = ListBox1.Items.IndexOf(button.Name)
        Dim stRuta As String = ""
        Dim openFD As New OpenFileDialog()
        With openFD
            .Title = "Abreme"
            .Filter = "Archivos Text (*.Lnk*.lnk)|*.Lnk; *lnk|Todos los archivos (*.*)|*.*"
            .Multiselect = False
            .InitialDirectory = My.Computer.FileSystem.SpecialDirectories.Desktop
            If .ShowDialog = Windows.Forms.DialogResult.OK Then
                safeFileName = openFD.SafeFileName
                fileName = openFD.FileName
                With openFD
                    .Title = "Subir Imagen"
                    .Filter = "Archivos Ico (*.Ico*.ico)|*.Ico; *ico|Archivos Png (*.Png*.png)|*.Png; *png|Todos los archivos (*.*)|*.*"
                    .Multiselect = False
                    .InitialDirectory = My.Computer.FileSystem.SpecialDirectories.Desktop
                    If .ShowDialog = Windows.Forms.DialogResult.OK Then
                        Try
                            System.IO.File.Copy(openFD.FileName, Application.StartupPath & "\Imagenes\" & openFD.SafeFileName)
                        Catch c As Exception
                        End Try
                        ListBox1.Items.Insert(indice, safeFileName)
                        ListBox3.Items.Insert(indice, fileName)
                        ListBox4.Items.Insert(indice, Application.StartupPath & "\Imagenes\" & openFD.SafeFileName)
                        guardarArchivos()
                        borrarObjeto(e, e)
                    End If
                End With
            End If
        End With
    End Sub

    Sub objetoButton()
        For Each objects In Me.Controls
            If TypeOf (objects) Is Button Then
                Dim button As Button = objects
                button.Visible = True
            End If
        Next
    End Sub
    Sub borrarObjeto(sender As Object, e As EventArgs)
        modalidad = "Stand_by"
        Me.Controls.Clear()
        InitializeComponent()
        Form1_Load(e, e)
    End Sub

    Sub guardarArchivos()
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
End Class