Imports MultiMedia
Imports System.Runtime.InteropServices
Imports System.ComponentModel
Imports System.IO

Public Class Form1
    Dim wavreal As Integer
    Dim drag As Boolean
    Dim mousex As Integer
    Dim mousey As Integer
    Dim filename As String
    Dim directory As String
    'Define the pic and graphics to draw with
    Dim pic As New Bitmap(Me.Width, Me.Height)
    Dim gfx As Graphics = Graphics.FromImage(pic)

    'Data storage
    Dim samplez As New List(Of Short)
    Dim maxamount As Short
    '//KEYBOARD INPUT
    Public Declare Function GetAsyncKeyState Lib "user32" (ByVal vKey As Integer) As Short
    Public Function GetKeyState(ByVal Key1 As Integer, Optional ByVal Key2 As Integer = -1, Optional ByVal Key3 As Integer = -1) As Boolean
        Dim s As Short
        s = GetAsyncKeyState(Key1)
        If s = 0 Then Return False
        If Key2 > -1 Then
            s = GetAsyncKeyState(Key2)
            If s = 0 Then Return False
        End If
        If Key3 > -1 Then
            s = GetAsyncKeyState(Key3)
            If s = 0 Then Return False
        End If
        Return True
    End Function
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        wavreal = 0
        FlatTrackBar1.Value = 50
        FlatTrackBar2.Value = 50

        Try
            RichTextBox2.LoadFile("repader.dll", RichTextBoxStreamType.PlainText)
        Catch ex As Exception

        End Try
        Try
            TextBox2.Text = RichTextBox2.Lines(1)
            TextBox3.Text = RichTextBox2.Lines(2)
            TextBox4.Text = RichTextBox2.Lines(3)
            TextBox5.Text = RichTextBox2.Lines(4)
            TextBox6.Text = RichTextBox2.Lines(5)

            TextBox11.Text = RichTextBox2.Lines(6)
            TextBox10.Text = RichTextBox2.Lines(7)
            TextBox9.Text = RichTextBox2.Lines(8)
            TextBox8.Text = RichTextBox2.Lines(9)
            TextBox7.Text = RichTextBox2.Lines(10)

            TextBox16.Text = RichTextBox2.Lines(11)
            TextBox15.Text = RichTextBox2.Lines(12)
            TextBox14.Text = RichTextBox2.Lines(13)
            TextBox13.Text = RichTextBox2.Lines(14)
            TextBox12.Text = RichTextBox2.Lines(15)
        Catch ex As Exception

        End Try

    End Sub

    Private Sub Loader_Click(sender As Object, e As EventArgs) Handles Loader.Click
        Dim myStreamReader As System.IO.StreamReader

        OpenFileDialog1.Filter = "WAV FILE | *.wav"
        OpenFileDialog1.FileName = "Sounds.wav"
        OpenFileDialog1.CheckFileExists = True

        If OpenFileDialog1.ShowDialog = DialogResult.OK Then

            Try
                OpenFileDialog1.OpenFile()
                myStreamReader = System.IO.File.OpenText(OpenFileDialog1.FileName)
                RichTextBox1.Text = myStreamReader.ReadToEnd()
                getfull()


            Catch ex As Exception
                MsgBox(ex.Message)
            End Try


        End If
    End Sub
    Private Sub getfull()
        Dim locate, myfilename, myfullpath As String
        locate = Path.GetDirectoryName(OpenFileDialog1.FileName)
        myfilename = Path.GetFileName(OpenFileDialog1.FileName)
        myfullpath = locate & "\" & myfilename
        Label1.Text = myfullpath
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'My.Computer.Audio.Play(Label1.Text)
        AxWindowsMediaPlayer1.Ctlcontrols.play()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        AxWindowsMediaPlayer1.Ctlcontrols.stop()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        AxWindowsMediaPlayer1.Ctlcontrols.pause()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
        AxWindowsMediaPlayer1.URL = ListBox1.SelectedItem
        TextBox1.Text = "Now Playing :    " & ListBox1.SelectedItem
        NotifyIcon1.BalloonTipText = TextBox1.Text
    End Sub

    Private Sub HScrollBar2_Scroll(sender As Object, e As ScrollEventArgs)


    End Sub

    Private Sub HScrollBar1_Scroll(sender As Object, e As ScrollEventArgs)

    End Sub

    Private Sub Label2_MouseDown(sender As Object, e As MouseEventArgs) Handles Label2.MouseDown, Label12.MouseDown
        drag = True 'Sets the variable drag to true.
        mousex = Windows.Forms.Cursor.Position.X - Me.Left 'Sets variable mousex
        mousey = Windows.Forms.Cursor.Position.Y - Me.Top 'Sets variable mousey
    End Sub

    Private Sub Label2_MouseMove(sender As Object, e As MouseEventArgs) Handles Label2.MouseMove, Label12.MouseMove
        If drag Then
            Me.Top = Windows.Forms.Cursor.Position.Y - mousey
            Me.Left = Windows.Forms.Cursor.Position.X - mousex
        End If
    End Sub

    Private Sub Label2_MouseUp(sender As Object, e As MouseEventArgs) Handles Label2.MouseUp, Label12.MouseUp
        drag = False
    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click
        Application.Exit()
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1x.Click
        If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.Cancel Then

        Else
            ListBox1.Items.Add(OpenFileDialog1.FileName)
            PictureBox1.Image = pic

        End If
    End Sub

    Private Sub Button5_Click_1(sender As Object, e As EventArgs)

    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        ListBox1.Items.Clear()
    End Sub

    Private Sub Label9_Click(sender As Object, e As EventArgs) Handles Label9.Click
        TabControl1.SelectTab(2)
    End Sub

    Private Sub FlatTrackBar2_Scroll(sender As Object) Handles FlatTrackBar2.Scroll

        AxWindowsMediaPlayer1.settings.volume = FlatTrackBar2.Value
        Label6.Text = "VOLUME : " & FlatTrackBar2.Value
        CircularProgressBar1.Value = FlatTrackBar2.Value
    End Sub

    Private Sub FlatTrackBar1_Scroll(sender As Object) Handles FlatTrackBar1.Scroll
        AxWindowsMediaPlayer1.settings.balance = FlatTrackBar1.Value
        Label7.Text = "LEFT / RIGHT : " & FlatTrackBar1.Value
        CircularProgressBar2.Value = FlatTrackBar1.Value
    End Sub

    Private Sub TabPage2_Click(sender As Object, e As EventArgs) Handles TabPage2.Click

    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click
        TabControl1.SelectTab(0)
    End Sub

    Private Sub Label10_Click(sender As Object, e As EventArgs) Handles Label10.Click
        TabControl1.SelectTab(1)
    End Sub

    Private Sub Label11_Click(sender As Object, e As EventArgs) Handles Label11.Click
        TabControl1.SelectTab(3)
    End Sub

    Private Sub PictureBox3_MouseHover(sender As Object, e As EventArgs) Handles PictureBox3.MouseHover

    End Sub

    Private Sub TextBox2_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox2.KeyDown
        Dim Code As String
        Code = e.KeyCode
        TextBox2.Text = Code
    End Sub

    Private Sub TextBox3_KeyDown(sender As Object, e As KeyEventArgs)

    End Sub

    Private Sub TextBox3_KeyDown_1(sender As Object, e As KeyEventArgs) Handles TextBox3.KeyDown
        Dim Code As String
        Code = e.KeyCode
        TextBox3.Text = Code
    End Sub

    Private Sub TextBox4_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox4.KeyDown
        Dim Code As String
        Code = e.KeyCode
        TextBox4.Text = Code
    End Sub

    Private Sub TextBox5_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox5.KeyDown
        Dim Code As String
        Code = e.KeyCode
        TextBox5.Text = Code
    End Sub

    Private Sub TextBox6_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox6.KeyDown
        Dim Code As String
        Code = e.KeyCode
        TextBox6.Text = Code
    End Sub

    Private Sub TextBox11_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox11.KeyDown
        Dim Code As String
        Code = e.KeyCode
        TextBox11.Text = Code '11
    End Sub

    Private Sub TextBox10_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox10.KeyDown
        Dim Code As String
        Code = e.KeyCode
        TextBox10.Text = Code '10
    End Sub

    Private Sub TextBox9_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox9.KeyDown
        Dim Code As String
        Code = e.KeyCode
        TextBox9.Text = Code '9
    End Sub

    Private Sub TextBox8_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox8.KeyDown
        Dim Code As String
        Code = e.KeyCode
        TextBox8.Text = Code '8
    End Sub

    Private Sub TextBox7_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox7.KeyDown
        Dim Code As String
        Code = e.KeyCode
        TextBox7.Text = Code '7
    End Sub

    Private Sub TextBox16_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox16.KeyDown
        Dim Code As String
        Code = e.KeyCode
        TextBox16.Text = Code '16
    End Sub

    Private Sub TextBox15_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox15.KeyDown
        Dim Code As String
        Code = e.KeyCode
        TextBox15.Text = Code '13
    End Sub

    Private Sub TextBox14_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox14.KeyDown
        Dim Code As String
        Code = e.KeyCode
        TextBox14.Text = Code '14
    End Sub

    Private Sub TextBox13_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox13.KeyDown
        Dim Code As String
        Code = e.KeyCode
        TextBox13.Text = Code '13
    End Sub

    Private Sub TextBox12_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox12.KeyDown
        Dim Code As String
        Code = e.KeyCode
        TextBox12.Text = Code '12
    End Sub

    Private Sub PictureBox18_Click(sender As Object, e As EventArgs) Handles PictureBox18.Click
        RichTextBox2.Text = ""
        Timer1.Start()


        RichTextBox2.AppendText(Environment.NewLine + TextBox2.Text)
        RichTextBox2.AppendText(Environment.NewLine + TextBox3.Text)
        RichTextBox2.AppendText(Environment.NewLine + TextBox4.Text)
        RichTextBox2.AppendText(Environment.NewLine + TextBox5.Text)
        RichTextBox2.AppendText(Environment.NewLine + TextBox6.Text)

        RichTextBox2.AppendText(Environment.NewLine + TextBox11.Text)
        RichTextBox2.AppendText(Environment.NewLine + TextBox10.Text)
        RichTextBox2.AppendText(Environment.NewLine + TextBox9.Text)
        RichTextBox2.AppendText(Environment.NewLine + TextBox8.Text)
        RichTextBox2.AppendText(Environment.NewLine + TextBox7.Text)

        RichTextBox2.AppendText(Environment.NewLine + TextBox16.Text)
        RichTextBox2.AppendText(Environment.NewLine + TextBox15.Text)
        RichTextBox2.AppendText(Environment.NewLine + TextBox14.Text)
        RichTextBox2.AppendText(Environment.NewLine + TextBox13.Text)
        RichTextBox2.AppendText(Environment.NewLine + TextBox12.Text)


        Try
            RichTextBox2.SaveFile("repader.dll", RichTextBoxStreamType.PlainText)
        Catch ex As Exception

        End Try

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If FlatToggle1.Checked = True Then
            wavreal = 1

        Else
            wavreal = 0
        End If
        'STATE 1
        If TextBox2.Text = "" Then


        Else
            Try
                If (GetAsyncKeyState(TextBox2.Text)) Then
                    Try
                        ListBox1.SelectedIndex = 0
                    Catch ex As Exception

                    End Try


                End If
            Catch ex As Exception

            End Try

        End If

        If TextBox3.Text = "" Then

        Else
            Try
                If (GetAsyncKeyState(TextBox3.Text)) Then
                    Try
                        ListBox1.SelectedIndex = 1
                    Catch ex As Exception

                    End Try


                End If
            Catch ex As Exception

            End Try



        End If

        If TextBox4.Text = "" Then

        Else
            Try
                If (GetAsyncKeyState(TextBox4.Text)) Then
                    Try
                        ListBox1.SelectedIndex = 2
                    Catch ex As Exception

                    End Try


                End If
            Catch ex As Exception

            End Try


        End If


        If TextBox5.Text = "" Then

        Else
            Try

            Catch ex As Exception

            End Try
            If (GetAsyncKeyState(TextBox5.Text)) Then
                Try
                    ListBox1.SelectedIndex = 3
                Catch ex As Exception

                End Try


            End If


        End If

        If TextBox6.Text = "" Then

            Try
                If (GetAsyncKeyState(TextBox6.Text)) Then
                    Try
                        ListBox1.SelectedIndex = 4
                    Catch ex As Exception

                    End Try


                End If
            Catch ex As Exception

            End Try
        End If

        'STATE 2


        If TextBox11.Text = "" Then

        Else
            Try

            Catch ex As Exception

            End Try
            If (GetAsyncKeyState(TextBox11.Text)) Then
                Try
                    ListBox1.SelectedIndex = 5
                Catch ex As Exception

                End Try


            End If

        End If


        If TextBox10.Text = "" Then

        Else
            Try

            Catch ex As Exception

            End Try
            If (GetAsyncKeyState(TextBox10.Text)) Then
                Try
                    ListBox1.SelectedIndex = 6
                Catch ex As Exception

                End Try


            End If

        End If

        If TextBox9.Text = "" Then

        Else
            Try

            Catch ex As Exception

            End Try
            If (GetAsyncKeyState(TextBox9.Text)) Then
                Try
                    ListBox1.SelectedIndex = 7
                Catch ex As Exception

                End Try


            End If

        End If


        If TextBox8.Text = "" Then

        Else
            Try

            Catch ex As Exception

            End Try
            If (GetAsyncKeyState(TextBox8.Text)) Then
                Try
                    ListBox1.SelectedIndex = 8
                Catch ex As Exception

                End Try


            End If

        End If


        If TextBox7.Text = "" Then

        Else
            Try
                If (GetAsyncKeyState(TextBox7.Text)) Then
                    ListBox1.SelectedIndex = 9

                End If
            Catch ex As Exception

            End Try



        End If





        'STATE 3
        If TextBox16.Text = "" Then

        Else
            Try
                If (GetAsyncKeyState(TextBox16.Text)) Then
                    ListBox1.SelectedIndex = 11

                End If
            Catch ex As Exception

            End Try


        End If



        If TextBox15.Text = "" Then

        Else
            Try
                If (GetAsyncKeyState(TextBox15.Text)) Then
                    ListBox1.SelectedIndex = 12

                End If

            Catch ex As Exception

            End Try

        End If


        If TextBox14.Text = "" Then

        Else
            Try
                If (GetAsyncKeyState(TextBox14.Text)) Then
                    ListBox1.SelectedIndex = 13

                End If
            Catch ex As Exception

            End Try


        End If


        If TextBox13.Text = "" Then

        Else
            Try
                If (GetAsyncKeyState(TextBox13.Text)) Then
                    ListBox1.SelectedIndex = 14

                End If
            Catch ex As Exception

            End Try


        End If





        Try
            If (GetAsyncKeyState(TextBox12.Text)) Then
                AxWindowsMediaPlayer1.Ctlcontrols.stop()
                AxWindowsMediaPlayer1.Ctlcontrols.play()

            End If
        Catch ex As Exception

        End Try






    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs)


    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        '   AxWindowsMediaPlayer1.
    End Sub

    Private Sub NotifyIcon1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles NotifyIcon1.MouseDoubleClick
        Me.Show()
        NotifyIcon1.Visible = False
    End Sub

    Private Sub Label28_Click(sender As Object, e As EventArgs) Handles Label28.Click
        NotifyIcon1.Visible = True
        Me.Hide()
    End Sub

    Private Sub PictureBox19_Click(sender As Object, e As EventArgs) Handles PictureBox19.Click
        RichTextBox2.Text = ""
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        TextBox5.Clear()
        TextBox6.Clear()
        TextBox7.Clear()
        TextBox8.Clear()
        TextBox9.Clear()
        TextBox10.Clear()
        TextBox11.Clear()
        TextBox12.Clear()
        TextBox13.Clear()
        TextBox14.Clear()
        TextBox15.Clear()
        TextBox16.Clear()

    End Sub

    Private Sub OpenFileDialog1_FileOk(sender As Object, e As CancelEventArgs) Handles OpenFileDialog1.FileOk
        If wavreal = 1 Then
            GC.Collect()
            Dim wavefile() As Byte = IO.File.ReadAllBytes(OpenFileDialog1.FileName)
            GC.Collect()

            Dim memstream As New IO.MemoryStream(wavefile)
            Dim binreader As New IO.BinaryReader(memstream)

            Dim ChunkID As Integer = binreader.ReadInt32()
            Dim filesize As Integer = binreader.ReadInt32()
            Dim rifftype As Integer = binreader.ReadInt32()
            Dim fmtID As Integer = binreader.ReadInt32()
            Dim fmtsize As Integer = binreader.ReadInt32()
            Dim fmtcode As Integer = binreader.ReadInt16()
            Dim channels As Integer = binreader.ReadInt16()
            Dim samplerate As Integer = binreader.ReadInt32()
            Dim fmtAvgBPS As Integer = binreader.ReadInt32()
            Dim fmtblockalign As Integer = binreader.ReadInt16()
            Dim bitdepth As Integer = binreader.ReadInt16()

            If fmtsize = 18 Then
                Dim fmtextrasize As Integer = binreader.ReadInt16()
                binreader.ReadBytes(fmtextrasize)
            End If

            Dim DataID As Integer = binreader.ReadInt32()
            Dim DataSize As Integer = binreader.ReadInt32()

            'Grabbing the data into 16bit words known as samples
            samplez.Clear()
            For i = 0 To (DataSize - 1) / 2

                samplez.Add(binreader.ReadInt16())

                If samplez(samplez.Count - 1) > maxamount Then 'Using this for the pic
                    maxamount = samplez(samplez.Count - 1)
                End If

            Next

            DrawAudio()
        Else

        End If




    End Sub
    Private Sub DrawAudio()

        'Redefine since size changed
        pic = New Bitmap(PictureBox1.Width, PictureBox1.Height)
        gfx = Graphics.FromImage(pic)

        'Clear picturebox
        gfx.FillRectangle(Brushes.Black, 0, 0, pic.Width, pic.Height)


        Dim ratio As Integer = (samplez.Count - 1) / (pic.Width - 1) 'If there are 10000 samples and 200 pixels, this would be every 50th sample is shown
        Dim halfpic As Integer = (pic.Height / 2) 'Simply half the height of the picturebox

        For i = 1 To pic.Width - 10 Step 2 'Steping 2 because in one go, we do 2 samples
            Dim leftdata As Integer = Math.Abs(samplez(i * ratio)) 'Grabbing that N-th sample to display. Using Absolute to show them one direction
            Dim leftpercent As Single = leftdata / (maxamount * 2) 'This breaks it down to something like 0.0 to 1.0. Multiplying by 2 to make it half.
            Dim leftpicheight As Integer = leftpercent * pic.Height 'So when the percent is tied to the height, its only a percent of the height
            gfx.DrawLine(Pens.LimeGreen, i, halfpic, i, leftpicheight + halfpic) 'Draw dat! The half pic puts it in the center

            Dim rightdata As Integer = Math.Abs(samplez((i + 1) * ratio)) 'Same thing except we're grabbing i + 1 because we'd skip it because of the 'step 2' on the for statement
            Dim rightpercent As Single = -rightdata / (maxamount * 2) 'put a negative infront of data so it goes down.
            Dim rightpicheight As Integer = rightpercent * pic.Height
            gfx.DrawLine(Pens.Blue, i, halfpic, i, rightpicheight + halfpic)

        Next

        PictureBox1.Image = pic

    End Sub
End Class