Imports System.Web.Script.Serialization
Imports System.IO
Imports System.Diagnostics
Imports System.ComponentModel
Imports System.Threading

Public Class Form1
    Private WithEvents bgWorker As New BackgroundWorker()
    Private numFiles As Integer = 0
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        scale_2.Checked = True
        output_scale.SelectedIndex = 1
        model.SelectedIndex = 0
        img_1.Checked = True
        OpenFileDialog1.FileName = ""

        Dim threadCount As Integer = Environment.ProcessorCount
        Console.WriteLine($"Number of CPU threads: {threadCount}")
        For i As Integer = 1 To threadCount
            cpu_limit.Items.Add(i)
        Next
        cpu_limit.SelectedIndex = cpu_limit.Items.Count - 1
        onload_file_paths()

        ' Configure the background worker
        bgWorker.WorkerReportsProgress = True
        bgWorker.WorkerSupportsCancellation = True

        AddHandler bgWorker.DoWork, AddressOf CheckFileCount
        AddHandler bgWorker.ProgressChanged, AddressOf UpdateFileCount
        AddHandler bgWorker.RunWorkerCompleted, AddressOf Cleanup




    End Sub
    Function read_profile()

        Dim fileContents As String = File.ReadAllText(profile_path.Text)
        Dim serializer As New JavaScriptSerializer()
        Dim deserializedData As Dictionary(Of String, Object) = serializer.Deserialize(Of Dictionary(Of String, Object))(fileContents)
        If deserializedData.ContainsKey("output_scale") Then
            output_scale.SelectedIndex = deserializedData("output_scale")
        End If
        If deserializedData.ContainsKey("downmix_audio") Then
            downmix_audio.CheckState = deserializedData("downmix_audio")
        End If
        If deserializedData.ContainsKey("ffmpeg_path") Then
            ffmpeg_path.Text = deserializedData("ffmpeg_path")
        End If
        If deserializedData.ContainsKey("esrgan_vulkan_path") Then
            esrgan_vulkan_path.Text = deserializedData("esrgan_vulkan_path")
        End If
        If deserializedData.ContainsKey("temp_path") Then
            temp_path.Text = deserializedData("temp_path")
        End If
        If deserializedData.ContainsKey("upscale_path") Then
            upscale_path.Text = deserializedData("upscale_path")
        End If
        If deserializedData.ContainsKey("use_ffmpeg_system") Then
            use_ffmpeg_system.Checked = deserializedData("use_ffmpeg_system")
        End If
        If deserializedData.ContainsKey("scale_2") Then
            scale_2.Checked = deserializedData("scale_2")
        End If
        If deserializedData.ContainsKey("scale_3") Then
            scale_3.Checked = deserializedData("scale_3")
        End If
        If deserializedData.ContainsKey("scale_4") Then
            scale_4.Checked = deserializedData("scale_4")
        End If
        If deserializedData.ContainsKey("img_1") Then
            img_1.Checked = deserializedData("img_1")
        End If
        If deserializedData.ContainsKey("img_2") Then
            img_2.Checked = deserializedData("img_2")
        End If
        If deserializedData.ContainsKey("img_3") Then
            img_3.Checked = deserializedData("img_3")
        End If
        If deserializedData.ContainsKey("model") Then
            model.SelectedIndex = deserializedData("model")
        End If
        If deserializedData.ContainsKey("clear_temp_box") Then
            clear_temp_box.CheckState = deserializedData("clear_temp_box")
        End If
        If deserializedData.ContainsKey("clear_upscale_box") Then
            clear_upscale_box.CheckState = deserializedData("clear_upscale_box")
        End If
        If deserializedData.ContainsKey("deinterlace") Then
            deinterlace.CheckState = deserializedData("deinterlace")
        End If
        If deserializedData.ContainsKey("check_prepvideo") Then
            check_prepvideo.CheckState = deserializedData("check_prepvideo")
        End If
        If deserializedData.ContainsKey("cpu_limit_check") Then
            cpu_limit_check.CheckState = deserializedData("cpu_limit_check")
        End If
        If deserializedData.ContainsKey("cpu_limit") Then
            cpu_limit.SelectedIndex = deserializedData("cpu_limit")
        End If
    End Function

    Function clear_file_paths()
        Dim appDataPath As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)

        ' Create a subfolder for your application
        Dim myAppFolder As String = Path.Combine(appDataPath, "Upscaler")
        If Not Directory.Exists(myAppFolder) Then
            Directory.CreateDirectory(myAppFolder)
        End If

        ' Save the file to the AppData folder
        Dim filePath As String = Path.Combine(myAppFolder, "app_filepath.txt")
        If File.Exists(filePath) Then
            File.Delete(filePath)
        End If
        Return True
    End Function
    Function save_file_paths()
        clear_file_paths()
        Dim appDataPath As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)

        ' Create a subfolder for your application
        Dim myAppFolder As String = Path.Combine(appDataPath, "Upscaler")
        If Not Directory.Exists(myAppFolder) Then
            Directory.CreateDirectory(myAppFolder)
        End If

        ' Save the file to the AppData folder
        Dim filePath As String = Path.Combine(myAppFolder, "app_filepath.txt")
        Dim src = src_path.Text
        Dim target = output_path.Text
        Dim pro = profile_path.Text


        Using writer As New StreamWriter(filePath, True)
            ' Write a new line to the end of the file
            writer.WriteLine(src)
        End Using
        Using writer As New StreamWriter(filePath, True)
            ' Write a new line to the end of the file
            writer.WriteLine(target)
        End Using
        Using writer As New StreamWriter(filePath, True)
            ' Write a new line to the end of the file
            writer.WriteLine(pro)
        End Using
        Return True
    End Function

    Function onload_file_paths()
        Dim appDataPath As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)

        ' Create a subfolder for your application
        Dim myAppFolder As String = Path.Combine(appDataPath, "Upscaler")
        If Not Directory.Exists(myAppFolder) Then
            Directory.CreateDirectory(myAppFolder)
        End If

        ' Save the file to the AppData folder
        Dim filePath As String = Path.Combine(myAppFolder, "app_filepath.txt")

        If File.Exists(filePath) Then

            Dim lines As List(Of String) = File.ReadLines(filePath).ToList()
            src_path.Text = lines(0)
            output_path.Text = lines(1)
            profile_path.Text = lines(2)
            If Not profile_path.Text = "" Then
                read_profile()
            End If
        End If


            Return True
    End Function

    Function resume_from_crash()
        Dim appDataPath As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)

        ' Create a subfolder for your application
        Dim myAppFolder As String = Path.Combine(appDataPath, "Upscaler")
        If Not Directory.Exists(myAppFolder) Then
            Directory.CreateDirectory(myAppFolder)
        End If

        ' Save the file to the AppData folder
        Dim filePath As String = Path.Combine(myAppFolder, "app_crashhandler.txt")

        ' Read the lines of the file into a list
        Dim lines As List(Of String) = File.ReadLines(filePath).ToList()

        ' Get the last line of the file
        Dim lastLine As String = lines.LastOrDefault()
        Dim step_num = lines.Count
        Return step_num

    End Function

    Function clear_crash_step()
        Dim appDataPath As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)

        ' Create a subfolder for your application
        Dim myAppFolder As String = Path.Combine(appDataPath, "Upscaler")
        If Not Directory.Exists(myAppFolder) Then
            Directory.CreateDirectory(myAppFolder)
        End If

        ' Save the file to the AppData folder
        Dim filePath As String = Path.Combine(myAppFolder, "app_crashhandler.txt")
        If File.Exists(filePath) Then
            File.Delete(filePath)
        End If
        Return True
    End Function

    Function save_crash_step(ByVal this_step As String)
        ' Get the path to the AppData folder for the current user
        Dim appDataPath As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)
        Dim returns As Integer = 0
        ' Create a subfolder for your application
        Dim myAppFolder As String = Path.Combine(appDataPath, "Upscaler")
        If Not Directory.Exists(myAppFolder) Then
            Directory.CreateDirectory(myAppFolder)
        End If

        ' Save the file to the AppData folder
        Dim filePath As String = Path.Combine(myAppFolder, "app_crashhandler.txt")

        If Not File.Exists(filePath) Then
            File.Create(filePath).Dispose()
        End If

        ' Read the lines of the file into a list
        Dim lines As List(Of String) = File.ReadLines(filePath).ToList()

        ' Check if an item is in the list
        Dim in_list As Boolean = lines.Contains(this_step)
        If in_list Then
            returns = 1
        Else
            Using writer As New StreamWriter(filePath, True)
                ' Write a new line to the end of the file
                writer.WriteLine(this_step)
            End Using
            returns = 0
        End If

        Return returns

    End Function
    Private Sub CheckFileCount(sender As Object, e As DoWorkEventArgs)
        ' Dim folderPath As String = CType(e.Argument, String)
        Dim args As Tuple(Of String, Integer) = CType(e.Argument, Tuple(Of String, Integer))
        Dim folderPath As String = args.Item1
        Dim temp_count As Integer = args.Item2


        While Not bgWorker.CancellationPending
            Dim files() As String = Directory.GetFiles(folderPath, "*.*")
            numFiles = files.Length
            bgWorker.ReportProgress(numFiles, New Tuple(Of Integer, Integer)(numFiles, temp_count))
            Thread.Sleep(1000) ' Wait for 1 second
        End While
    End Sub

    Private Sub UpdateFileCount(sender As Object, e As ProgressChangedEventArgs)
        Dim msg = ""
        Dim args As Tuple(Of Integer, Integer) = CType(e.UserState, Tuple(Of Integer, Integer))
        ' Dim numFiles As String = args.Item1
        Dim temp_count As Integer = args.Item2

        If temp_count = 0 Then
            msg = ("Frames Ripped : " & numFiles)
        Else
            msg = ("Frames Proccessed : " & numFiles & "/" & temp_count)
        End If

        msg_info.Text = msg

    End Sub

    Private Sub Cleanup(sender As Object, e As RunWorkerCompletedEventArgs)
        Dim msg = ""
        msg_info.Text = msg


    End Sub

    Private Sub br_src_Click(sender As Object, e As EventArgs) Handles br_src.Click
        OpenFileDialog1.Title = "Select a Source Video file"
        OpenFileDialog1.Filter = "All Files (*.*)|*.*"

        ' Show the OpenFileDialog and check if the user clicked the OK button
        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            ' Set the TextBox text to the selected file path
            src_path.Text = OpenFileDialog1.FileName
        End If
    End Sub

    Private Sub br_output_Click(sender As Object, e As EventArgs) Handles br_output.Click
        SaveFileDialog1.Title = "Save output as"
        SaveFileDialog1.Filter = "Video File (*.mp4)|*.mp4|All Files (*.*)|*.*"
        SaveFileDialog1.DefaultExt = "mp4"

        ' Show the SaveFileDialog and check if the user clicked the OK button
        If SaveFileDialog1.ShowDialog() = DialogResult.OK Then
            ' Retrieve the selected file path
            output_path.Text = SaveFileDialog1.FileName
        End If
    End Sub

    Private Sub br_ffmpeg_Click(sender As Object, e As EventArgs) Handles br_ffmpeg.Click
        OpenFileDialog1.Title = "FFmpeg location"
        OpenFileDialog1.Filter = "Executable Files (*.exe)|*.exe"

        ' Show the OpenFileDialog and check if the user clicked the OK button
        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            ' Set the TextBox text to the selected file path
            ffmpeg_path.Text = OpenFileDialog1.FileName
        End If
    End Sub

    Private Sub br_esrgan_Click(sender As Object, e As EventArgs) Handles br_esrgan.Click
        OpenFileDialog1.Title = "Realesrgan vulkan location"
        OpenFileDialog1.Filter = "Executable Files (*.exe)|*.exe"

        ' Show the OpenFileDialog and check if the user clicked the OK button
        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            ' Set the TextBox text to the selected file path
            esrgan_vulkan_path.Text = OpenFileDialog1.FileName
        End If
    End Sub

    Private Sub br_temp_Click(sender As Object, e As EventArgs) Handles br_temp.Click
        If Not String.IsNullOrWhiteSpace(temp_path.Text) Then
            Dim filepath As String = Path.GetDirectoryName(temp_path.Text)
            FolderBrowserDialog1.SelectedPath = filepath
        End If
        FolderBrowserDialog1.Description = "Folder for temp frames"
        ' Show the FolderBrowserDialog and check if the user clicked the OK button
        If FolderBrowserDialog1.ShowDialog() = DialogResult.OK Then
            ' Set the TextBox text to the selected folder path
            temp_path.Text = FolderBrowserDialog1.SelectedPath
        End If
    End Sub

    Private Sub br_upscale_Click(sender As Object, e As EventArgs) Handles br_upscale.Click
        If Not String.IsNullOrWhiteSpace(upscale_path.Text) Then
            Dim filepath As String = Path.GetDirectoryName(upscale_path.Text)
            FolderBrowserDialog1.SelectedPath = filepath
        End If
        FolderBrowserDialog1.Description = "Folder for Upscale Frames"

        ' Show the FolderBrowserDialog and check if the user clicked the OK button
        If FolderBrowserDialog1.ShowDialog() = DialogResult.OK Then
            ' Set the TextBox text to the selected folder path
            upscale_path.Text = FolderBrowserDialog1.SelectedPath
        End If
    End Sub

    Private Sub save_profile_Click(sender As Object, e As EventArgs) Handles save_profile.Click
        Dim appPath As String = Application.StartupPath()
        SaveFileDialog1.InitialDirectory = appPath
        SaveFileDialog1.Title = "Save Profile as"
        SaveFileDialog1.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*"
        SaveFileDialog1.DefaultExt = "txt"
        If Not String.IsNullOrWhiteSpace(profile_path.Text) Then
            Dim fileName As String = Path.GetFileName(profile_path.Text)
            SaveFileDialog1.FileName = fileName
        End If
        ' Show the SaveFileDialog and check if the user clicked the OK button
        If SaveFileDialog1.ShowDialog() = DialogResult.OK Then
            ' Retrieve the selected file path
            profile_path.Text = SaveFileDialog1.FileName

            Dim profile_settings As New Dictionary(Of String, Object) From {
         {"output_scale", output_scale.SelectedIndex},
         {"downmix_audio", downmix_audio.CheckState},
         {"ffmpeg_path", ffmpeg_path.Text},
         {"esrgan_vulkan_path", esrgan_vulkan_path.Text},
         {"temp_path", temp_path.Text},
         {"upscale_path", upscale_path.Text},
         {"use_ffmpeg_system", use_ffmpeg_system.Checked},
         {"scale_2", scale_2.Checked},
         {"scale_3", scale_3.Checked},
         {"scale_4", scale_4.Checked},
         {"img_1", img_1.Checked},
         {"img_2", img_2.Checked},
         {"img_3", img_3.Checked},
         {"model", model.SelectedIndex},
         {"clear_temp_box", clear_temp_box.CheckState},
         {"clear_upscale_box", clear_upscale_box.CheckState},
         {"deinterlace", deinterlace.CheckState},
         {"check_prepvideo", check_prepvideo.CheckState},
         {"cpu_limit_check", cpu_limit_check.CheckState},
         {"cpu_limit", cpu_limit.SelectedIndex}
            }

            Dim serializer As New JavaScriptSerializer()
            Dim jsonObject As String = serializer.Serialize(profile_settings)
            System.IO.File.WriteAllText(profile_path.Text, jsonObject)



        End If
    End Sub

    Private Sub load_profile_Click(sender As Object, e As EventArgs) Handles load_profile.Click
        Dim appPath As String = Application.StartupPath()
        OpenFileDialog1.InitialDirectory = appPath
        OpenFileDialog1.Title = "Select a Profile"
        OpenFileDialog1.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*"

        ' Show the OpenFileDialog and check if the user clicked the OK button
        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            ' Set the TextBox text to the selected file path
            profile_path.Text = OpenFileDialog1.FileName
            read_profile()



        End If
    End Sub

    Private Sub use_ffmpeg_system_CheckedChanged(sender As Object, e As EventArgs) Handles use_ffmpeg_system.CheckedChanged
        If use_ffmpeg_system.Checked Then

            Dim ffmpeg_system = get_ffmpeg_system_path()
            ffmpeg_path.Text = ffmpeg_system
            If ffmpeg_system = "" Then
                MessageBox.Show("Could not find ffmpeg in path")
                use_ffmpeg_system.Checked = False
                Exit Sub
            End If
            br_ffmpeg.Enabled = False
            ffmpeg_path.Enabled = False

        Else
            ffmpeg_path.Enabled = True
            ffmpeg_path.Text = ""
            br_ffmpeg.Enabled = True
        End If
    End Sub

    Private Sub download_real_Click(sender As Object, e As EventArgs) Handles download_real.Click
        'https://github.com/xinntao/Real-ESRGAN
        Dim url As String = "https://github.com/xinntao/Real-ESRGAN/releases/download/v0.2.5.0/realesrgan-ncnn-vulkan-20220424-windows.zip"

        ' Open the URL in the default browser
        Try
            Process.Start(url)
        Catch ex As Exception
            ' Handle the exception if the browser could not be opened
            MessageBox.Show("Unable to open the link in the default browser.")
        End Try

    End Sub

    Private Sub download_ffmpeg_Click(sender As Object, e As EventArgs) Handles download_ffmpeg.Click
        'ffmpeg
        Dim url As String = "https://github.com/BtbN/FFmpeg-Builds/releases/download/latest/ffmpeg-master-latest-win64-gpl.zip"

        ' Open the URL in the default browser
        Try
            Process.Start(url)
        Catch ex As Exception
            ' Handle the exception if the browser could not be opened
            MessageBox.Show("Unable to open the link in the default browser.")
        End Try
    End Sub

    Function get_ffmpeg_system_path()
        Dim mpath As String = ""
        ' Specify the name of the executable file to check for
        Dim exeName As String = "ffmpeg.exe"
        Dim exePath As String = ""
        ' Get the value of the "Path" environment variable
        Dim pathValue As String = Environment.GetEnvironmentVariable("Path")

        ' Split the path value into a list of individual paths
        Dim paths As String() = pathValue.Split(";")

        ' Check if the executable file is in any of the paths
        Dim exeInPath As Boolean = False
        For Each path1 As String In paths
            exePath = Path.Combine(path1, exeName)

            If File.Exists(exePath) Then
                exeInPath = True
                Exit For
            End If
        Next

        ' Do something based on whether the executable file is in the system path
        If exeInPath Then
            ' The executable file is in the system path
            mpath = Path.GetFullPath(exePath)
        End If
        Return mpath


    End Function

    Function check_blanks()

        If String.IsNullOrWhiteSpace(ffmpeg_path.Text) Then
            If Not use_ffmpeg_system.Checked Then

                MessageBox.Show("Please select ffmpeg path")
                Return False

            Else

                If get_ffmpeg_system_path() = "" Then
                    MessageBox.Show("Could not find ffmpeg path")
                    Return False
                End If
            End If
        End If
        If String.IsNullOrWhiteSpace(esrgan_vulkan_path.Text) Then
            MessageBox.Show("Please select ESRGAN path")
            Return False
        End If
        If String.IsNullOrWhiteSpace(src_path.Text) Then
            MessageBox.Show("Please select source path")
            Return False
        End If
        If String.IsNullOrWhiteSpace(temp_path.Text) Then
            MessageBox.Show("Please select temp path")
            Return False
        End If
        If String.IsNullOrWhiteSpace(upscale_path.Text) Then
            MessageBox.Show("Please select upscale path")
            Return False
        End If
        If String.IsNullOrWhiteSpace(output_path.Text) Then
            MessageBox.Show("Please select output path")
            Return False
        End If
        Return True


    End Function
    Async Function clean_up_interrupt(temp_path As String, upscale_path As String) As Task
        Dim deletedCount1 = Await clear_folders(temp_path)
        Dim deletedCount2 = Await clear_folders(upscale_path)
        Dim parentDirectory As String = Path.GetDirectoryName(temp_path)
        clear_crash_step()
        If File.Exists(parentDirectory & "\temp_output.mp4") Then
            File.Delete(parentDirectory & "\temp_output.mp4")
        End If
        msg_info.Text = "Interrupted"

    End Function

    Private startTime As DateTime

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        ' This method is called every time the timer interval elapses
        Console.WriteLine("Tick")
    End Sub


    Private Async Sub go_btn_Click(sender As Object, e As EventArgs) Handles go_btn.Click
        ' Start the timer and record the start time
        Timer1.Interval = 1000 ' Set the interval to 1 second
        startTime = DateTime.Now
        Timer1.Start()


        ''check for blanks :)
        save_crash_step("blanks") '1
        Console.WriteLine("checking for blanks")
        If check_blanks() = False Then
            Exit Sub ' stop running
        End If

        'Console.WriteLine("Start timer")


        Console.WriteLine("Get Radios")
        save_crash_step("radios") '2
        Dim img_format = get_radio(img_format_box)
        Dim upscale_format = get_radio(upscale_box)


        Console.WriteLine("Make Folders")
        msg_info.Text = "Make Folders..."
        save_crash_step("folders") '3
        mkfolder(temp_path.Text)
        mkfolder(upscale_path.Text)



        'convert the video
        'ffmpeg -i < input_file > -c: v libx264 -preset slow -crf 23 -pix_fmt yuvj420p -c:a aac -b:a 160k temp_output.mp4 
        Console.WriteLine("create temp video")
        Dim prep_complete = 0
        If Not String.IsNullOrWhiteSpace(ffmpeg_path.Text) And Not String.IsNullOrWhiteSpace(src_path.Text) Then

            save_crash_step("temp_video") '4
            If resume_from_crash() = 4 Then
                st_1.Checked = True
                msg_info.Text = "Creating temp video..."
                prep_complete = prep_video(ffmpeg_path.Text, src_path.Text, Path.GetDirectoryName(temp_path.Text))

                If Not prep_complete = 0 Then
                    Dim result As DialogResult = MessageBox.Show("Did you want to discard all files and start over?", "Interrupt Detected", MessageBoxButtons.YesNo)
                    If result = DialogResult.Yes Then
                        Await clean_up_interrupt(temp_path.Text, upscale_path.Text)
                        Exit Sub
                    Else
                        ' User clicked No or closed the message box
                        ' Cancel the action
                    End If
                End If

            End If
        Else
            Exit Sub
        End If

        ''get_framerate
        Dim frame_rate As Double = 0.00
        Console.WriteLine("Get Framerate")
        save_crash_step("framerate") '5
        msg_info.Text = "Getting FrameRate..."
        frame_rate = get_framerate(Path.GetDirectoryName(ffmpeg_path.Text), Path.GetDirectoryName(temp_path.Text) & "\temp_output.mp4")
        'rip the frames


        Dim rip_result = 0
        If prep_complete = 0 And frame_rate > 0 Then
            save_crash_step("rip_frames") '6
            If resume_from_crash() = 6 Then
                Console.WriteLine("Ripping Frames")
                st_2.Checked = True
                msg_info.Text = "Ripping frames..."
                rip_result = Await rip_frames(ffmpeg_path.Text, temp_path.Text, img_format)
                If Not rip_result = 0 Then
                    Dim result As DialogResult = MessageBox.Show("Did you want to discard all files and start over?", "Interrupt Detected", MessageBoxButtons.YesNo)
                    If result = DialogResult.Yes Then
                        Await clean_up_interrupt(temp_path.Text, upscale_path.Text)
                        Exit Sub
                    Else
                        ' User clicked No or closed the message box
                        ' Cancel the action
                    End If
                End If
                Console.WriteLine(rip_result)
            End If
        Else
            Exit Sub
        End If

        'upscale
        Console.WriteLine("Upscale Frames")

        Dim upscale_result = 0
        If rip_result = 0 Then
            save_crash_step("upscale_frames") '7
            If resume_from_crash() = 7 Then

                st_3.Checked = True
                msg_info.Text = "Upscale frames..."
                upscale_result = Await upscale(esrgan_vulkan_path.Text, temp_path.Text, upscale_path.Text, model.Text, upscale_format, img_format)

            End If
        Else
            Exit Sub
        End If


        Console.WriteLine("Create final video")

        Dim create_result = 0


        If upscale_result = 0 Then
            save_crash_step("create_final") '8
            If resume_from_crash() = 8 Then

                st_4.Checked = True
                msg_info.Text = "Create Video..."
                create_result = create_video(ffmpeg_path.Text, upscale_path.Text, temp_path.Text, img_format, frame_rate, res_lookup(output_scale.Text), output_path.Text)
            End If
        Else
            Exit Sub
        End If



        Console.WriteLine("Clean up")

        If create_result = 0 Then
            save_crash_step("clean") '9
            st_5.Checked = True
            If clear_temp_box.Checked Then
                msg_info.Text = "Deleting temp frames..."
                Dim deletedCount = Await clear_folders(temp_path.Text)
            End If

            If clear_upscale_box.Checked Then
                msg_info.Text = "Deleting upscale frames..."
                Dim deletedCount = Await clear_folders(upscale_path.Text)
            End If
        Else
            Exit Sub
        End If
        Console.WriteLine("Done")
        save_crash_step("done") '10
        If (resume_from_crash() = 10) Then
            clear_crash_step()
        End If

        st_1.Checked = True
        msg_info.Text = "Status messsage"

        ' Stop the timer and calculate the elapsed time
        Timer1.Stop()
        Dim elapsedTime As TimeSpan = DateTime.Now - startTime
        Console.WriteLine("Elapsed time: " & elapsedTime.ToString("hh\:mm\:ss"))
        msg_info.Text = "Elapsed time: " & elapsedTime.ToString("hh\:mm\:ss")
        'Console.WriteLine("Stop Timer")
        ' Stop the timer


        ' Get the elapsed time
        ' Console.WriteLine("Clean up")


    End Sub

    Public Function res_lookup(ByVal res As String)
        Dim scale_out As String
        scale_out = "1920x1080"
        If res.Contains("720p") Then
            scale_out = "1280x720"
        End If

        If res.Contains("1080p") Then
            scale_out = "1920x1080"
        End If

        If res.Contains("2k") Then
            scale_out = "2048x1080"
        End If

        If res.Contains("4k") Then
            scale_out = "2048x2160"
        End If

        Return scale_out


    End Function

    Public Function create_video(ByVal ffmpeg As String, ByVal upscale_path As String, ByVal temp_path As String, ByVal ext As String, ByVal frame_rate As Double, ByVal ff_scale As String, ByVal output_file As String)
        'ffmpeg -r < inspected_fr > -i < upscale_frames >/ frame%08d.<ext> -preset veryslow -crf 18 -i temp_output.mp4 -map 0:v : 0 -map 1:a : 0 -c:a copy - c: v libx264 - r < inspected_fr > -pix_fmt - pix_fmt yuvj420p -vf scale=<ff_scale> <output_file>
        Dim audio_command = "-c:a copy"
        If downmix_audio.Checked Then
            audio_command = "-filter:a:0 ""pan=stereo|FL=1.414*FC+0.707*FL+0.5*FLC+0.5*BL+0.5*SL+0.5*LFE|FR=1.414*FC+0.707*FR+0.5*FRC+0.5*BR+0.5*SR+0.5*LFE,acompressor=ratio=4"" -metadata:s:a:0 title=""Custom DRC"" -metadata:s:a:0 language=eng -disposition:a:0 default -map 0:a:0? -c:a:1 copy -disposition:a:1 none -map 0:a:1? -c:a:2 copy -disposition:a:2 none -map 0:a:2? -c:a:3 copy -disposition:a:3 none -map 0:a:3? -c:a:4 copy -disposition:a:4 none -map 0:a:4? -c:a:5 copy -disposition:a:5 none -map 0:a:5? -c:a:6 copy -disposition:a:6 none -map 0:a:6? -c:a:7 copy -disposition:a:7 none -map 0:a:7? -c:a:8 copy -disposition:a:8 none -map 0:a:8? -c:a:9 copy -disposition:a:9 none -map 0:s:0? -c:s:0 copy -map 0:s:1? -c:s:1 copy -map 0:s:2? -c:s:2 copy -map 0:s:3? -c:s:3 copy -map 0:s:4? -c:s:4 copy -map 0:s:5? -c:s:5 copy -map 0:s:6? -c:s:6 copy -map 0:s:7? -c:s:7 copy -map 0:s:8? -c:s:8 copy -map 0:s:9? -c:s:9 copy"
        End If

        Dim threads = ""
        If (cpu_limit_check.Checked) Then
            If (cpu_limit.SelectedItem > 0) Then
                threads = "-threads " & cpu_limit.SelectedItem
            End If
        End If



        Dim temp_path_file = Path.GetDirectoryName(temp_path)
        Dim Command = ffmpeg
        Dim arguments = String.Format(" -y {7} -r {0} -i {1}\frame%08d.{2} -preset veryslow -crf 18 -i {3}\temp_output.mp4 -map 0:v:0 -map 1:a:0 {6} -c:v libx264 -r {0} -pix_fmt yuvj420p -vf scale={4} {5} ", frame_rate, upscale_path, ext, temp_path_file, ff_scale, output_file, audio_command, threads)
        Dim exitCode As Integer = 0
        ' Console.WriteLine(arguments)
        Dim startInfo As New ProcessStartInfo(Command, arguments)
        Dim process As Process = Process.Start(startInfo)

        ' Read the standard output of the process into a string
        'Dim output As String = process.StandardOutput.ReadToEnd()

        ' Wait for the process to exit
        process.WaitForExit()
        If process.HasExited Then
            ' Process has exited, check the exit code
            exitCode = process.ExitCode
        Else
            exitCode = 999
        End If


        Return exitCode


    End Function


    Public Async Function upscale(ByVal realpath As String, ByVal temp_path As String, ByVal upscale_path As String, ByVal model As String, ByVal scale As String, ByVal ext As String) As Task(Of Integer)

        '<realesrgan-ncnn-vulkan.exe> -i <tempframes> -o <upscale_frames> -n <model> -s <scale> -f <ext>

        Dim files() As String = Directory.GetFiles(temp_path, "*.*")
        Dim temp_count As Integer = files.Length
        'count_frames(upscale_path, temp_count)

        Dim Command = realpath
        Dim arguments = String.Format(" -i {0} -o {1} -n {2} -s {3} -f {4}", temp_path, upscale_path, model, scale, ext)
        Dim ps_exitCode As Integer = 0
        Dim folder_exitCode As Integer = 0

        msg_info.Text = temp_count
        Dim aas As String = ""

        Dim progress As New Progress(Of String)(Sub(value) msg_info.Text = value)

        folder_exitCode = Await UpdateFileCountAsync(upscale_path, temp_count, msg_info, Command, arguments)
        ' ps_exitCode = Await RunProcessAsync(Command, arguments)


        'Dim result = exit_code.Result


        Return folder_exitCode

    End Function

    Private Async Function UpdateFileCountAsync(folderPath As String, temp_count As Integer, statusLabel As Label, Command As String, arguments As String) As Task(Of Integer)

        ' Create a cancellation token source
        Dim cts As New CancellationTokenSource()
        Dim msg = ""
        ' Run the update loop asynchronously
        Dim updateTask As Task = Task.Run(Async Function()
                                              ' Initialize the file count to 0
                                              Dim fileCount As Integer = 0
                                              Console.WriteLine("before while")
                                              ' Loop until the cancellation token is canceled
                                              While Not cts.Token.IsCancellationRequested
                                                  Try
                                                      ' Count the number of files in the directory
                                                      fileCount = Directory.GetFiles(folderPath).Length

                                                      ' Update the status label with the file count
                                                      If temp_count = 0 Then
                                                          msg = ("Frames Ripped : " & fileCount)
                                                      Else
                                                          msg = ("Frames Proccessed : " & fileCount & "/" & temp_count)
                                                      End If
                                                      statusLabel.Invoke(Sub() statusLabel.Text = msg)
                                                      ' Console.WriteLine("after invoke")
                                                      ' Wait for a shorter period of time before updating again
                                                      Await Task.Delay(100)
                                                      '  Console.WriteLine("Update loop executing")
                                                  Catch ex As Exception
                                                      ' Console.WriteLine("Error in update loop: " & ex.Message)
                                                  End Try
                                              End While


                                          End Function, cts.Token)

        Dim exit_code = Await RunProcessAsync(Command, arguments)
        ' Dim exit_code As Integer = waitTask.Result
        'Console.WriteLine("waitTask complete")
        ' Cancel the update loop
        cts.Cancel()
        ' Console.WriteLine("got cancel complete")
        ' Wait for the update loop to complete
        Await updateTask
        'Console.WriteLine("past updateTask")
        Return exit_code

    End Function


    Private Async Function RunProcessAsync(command As String, arguments As String) As Task(Of Integer)
        Dim processCompleted As Boolean = False
        Dim exitCode As Integer = -1 ' Default exit code in case of failure

        Try
            ' Configure the process
            Dim processStartInfo As New ProcessStartInfo With {
                .FileName = command,
                .Arguments = arguments
            }
            ' .RedirectStandardOutput = True,
            ' .RedirectStandardError = True,
            ' .UseShellExecute = False,
            ' .CreateNoWindow = True

            ' Start the process
            Using process As New Process With {.StartInfo = processStartInfo}
                process.EnableRaisingEvents = True

                Dim processTcs As New TaskCompletionSource(Of Boolean)()

                ' Handle process exited event
                AddHandler process.Exited, Sub(sender, e)
                                               exitCode = process.ExitCode ' Get the exit code of the process
                                               processTcs.TrySetResult(True)
                                           End Sub

                ' Start the process
                If process.Start() Then
                    ' Wait for the process to exit
                    processCompleted = Await processTcs.Task.ConfigureAwait(False)
                End If
            End Using
        Catch ex As Exception
            ' Handle any exceptions that occur during process execution
            Console.WriteLine("Error running process: " & ex.Message)
        End Try

        Return exitCode
    End Function


    Public Function mkfolder(ByVal folder As String) As String
        If Not Directory.Exists(folder) Then
            Directory.CreateDirectory(folder)
        End If
        Return True
    End Function

    Public Function get_radio(ByVal control_box As Control) As String
        Dim selectedRadioButton As RadioButton = Nothing
        For Each control As Control In control_box.Controls
            If TypeOf control Is RadioButton AndAlso CType(control, RadioButton).Checked Then
                selectedRadioButton = CType(control, RadioButton)
                Exit For
            End If
        Next

        If selectedRadioButton IsNot Nothing Then
            Console.WriteLine("Selected radio button: " & selectedRadioButton.Text)
        Else
            Console.WriteLine("No radio button selected.")
        End If

        Return selectedRadioButton.Text


    End Function

    Private Async Function clear_folders(directoryPath As String) As Task(Of Integer)

        Dim statusLabel = msg_info
        Dim fileCount As Integer = 0
        Dim deletedCount As Integer = 0

        ' Create a cancellation token source
        Dim cts As New CancellationTokenSource()
        Dim files = Directory.GetFiles(directoryPath, "frame*")
        ' If there are no files, break out of the loop
        If files.Length = 0 Then
            Return deletedCount
            Exit Function
        End If
        ' Run the update loop asynchronously
        Dim updateTask As Task = Task.Run(Async Function()
                                              ' Loop until the cancellation token is canceled
                                              While Not cts.Token.IsCancellationRequested
                                                  ' Delete each file in the directory
                                                  For Each file_a In files
                                                      Try
                                                          ' Delete the file
                                                          File.Delete(file_a)
                                                          Console.WriteLine(file_a)

                                                          ' Increment the deleted count
                                                          deletedCount += 1

                                                          ' Update the status label with the progress
                                                          fileCount = files.Length
                                                          Dim msg = "Deleted " & deletedCount & " of " & fileCount & " files"
                                                          statusLabel.Invoke(Sub() statusLabel.Text = msg)
                                                          If deletedCount = fileCount Then
                                                              Exit While

                                                          End If

                                                      Catch ex As Exception
                                                          ' Log any errors that occur while deleting the file
                                                          Debug.WriteLine(ex.Message)
                                                      End Try
                                                  Next

                                                  ' Wait for a few seconds before updating again
                                                  Await Task.Delay(300)
                                              End While
                                          End Function, cts.Token)

        Await updateTask

        Return deletedCount

    End Function



    Public Function stop_count()
        bgWorker.CancelAsync()
        Return True
    End Function
    Public Function count_frames(ByVal path As String, Optional temp_count As Integer = 0)
        bgWorker.RunWorkerAsync(New Tuple(Of String, Integer)(path, temp_count))
        Return True
    End Function

    Public Async Function rip_frames(ByVal ffmpeg As String, ByVal temp_frames_path As String, ByVal img_format As String) As Task(Of Integer)
        'ffmpeg -i temp_output.mp4 -qscale:v 1 -qmin 1 -qmax 1 -fps_mode passthrough <tempframes>/frame%08d.<ext>

        Dim temp_path = Path.GetDirectoryName(temp_frames_path)
        Dim Command = ffmpeg
        Dim threads = ""
        If (cpu_limit_check.Checked) Then
            If (cpu_limit.SelectedItem > 0) Then
                threads = "-threads " & cpu_limit.SelectedItem
            End If
        End If
        Dim arguments = String.Format(" -y {3} -i {0}/temp_output.mp4 -qscale:v 1 -qmin 1 -qmax 1 -fps_mode passthrough {1}/frame%08d.{2} ", temp_path, temp_frames_path, img_format, threads)
        Dim exitCode As Integer = 0
        Dim exit_code = Await UpdateFileCountAsync(temp_frames_path, "0", msg_info, Command, arguments)

        Return exit_code

    End Function
    Public Function prep_video(ByVal ffmpeg As String, ByVal input_file As String, ByVal temp_frames_path As String) As String

        Dim delace = ""
        If (deinterlace.Checked) Then
            delace = "-vf yadif=1"
        End If

        Dim threads = ""
        If (cpu_limit_check.Checked) Then
            If (cpu_limit.SelectedItem > 0) Then
                threads = "-threads " & cpu_limit.SelectedItem
            End If
        End If

        Dim Command = ffmpeg
        Dim arguments = String.Format(" -y {3} -i {0} -c:v libx264 -preset slow -crf 23 -pix_fmt yuvj420p {2} -c:a aac -b:a 160k {1}\temp_output.mp4 ", input_file, temp_frames_path, delace, threads)
        Dim exitCode As Integer = 0
        Dim startInfo As New ProcessStartInfo(Command, arguments)
        Dim process As Process = Process.Start(startInfo)

        ' Read the standard output of the process into a string
        'Dim output As String = process.StandardOutput.ReadToEnd()

        ' Wait for the process to exit
        process.WaitForExit()
        If process.HasExited Then
            ' Process has exited, check the exit code
            exitCode = process.ExitCode
        Else
            exitCode = 999
        End If

        If (check_prepvideo.Checked) Then
            '//temp_frames_path
            Process.Start(temp_frames_path & "\temp_output.mp4")
            Dim result As DialogResult = MessageBox.Show("Does the prep video look good and continue?", "Confirmation", MessageBoxButtons.YesNo)

            If result = DialogResult.Yes Then
                ' User clicked Yes
                exitCode = 0
            Else
                ' User clicked No or closed the dialog box
                exitCode = 2
            End If


        End If

        Return exitCode

    End Function

    Public Function get_framerate(ByVal ffmpeg_path As String, ByVal input_file As String) As String
        ' frame_rate = get_framerate(Path.GetDirectoryName(ffmpeg_path.Text), Path.GetDirectoryName(temp_path.Text) & "\temp_output.mp4")
        Dim Command = ffmpeg_path & "\ffprobe.exe"
        'Dim arguments = String.Format("-v error -hide_banner -select_streams v:0 -show_streams -print_format json -show_format {0}", input_file)
        'Dim arguments = String.Format("-v error -select_streams v:0 -show_entries stream=width,height,r_frame_rate,codec_name -of csv=p=0 {0}", input_file)
        Dim arguments = String.Format("-v error -select_streams v:0 -show_entries stream=r_frame_rate -of csv=p=0 {0}", input_file)
        'h264,1920,1080,2997/100
        ' h264 = codec_name
        ' 1920 with
        '1080 height
        'fr = 2977/100
        Dim startInfo As New ProcessStartInfo(Command, arguments)

        ' Redirect the standard output of the process to a stream reader
        startInfo.RedirectStandardOutput = True

        ' Set the UseShellExecute property to False to enable output redirection
        startInfo.UseShellExecute = False

        ' Create a new process and start it with the specified command and arguments
        Dim process As Process = Process.Start(startInfo)

        ' Read the standard output of the process into a string
        Dim output As String = process.StandardOutput.ReadToEnd()

        ' Wait for the process to exit
        process.WaitForExit()

        Dim fr_data() As String = output.Split("/")
        Dim fr As Double = Math.Round(fr_data(0) / fr_data(1), 2)
        Console.WriteLine(fr)
        ' Return the output as a string
        Return fr


        'Return framerate
    End Function

    Private Async Sub clear_temp_Click(sender As Object, e As EventArgs) Handles clear_temp.Click
        clear_temp.Enabled = False
        clear_upscale.Enabled = False
        If Not temp_path.Text = "" Then
            Dim deletedCount = Await clear_folders(temp_path.Text)
        End If
        clear_temp.Enabled = True
        clear_upscale.Enabled = True

    End Sub

    Private Async Sub clear_upscale_Click(sender As Object, e As EventArgs) Handles clear_upscale.Click
        clear_upscale.Enabled = False
        clear_temp.Enabled = False
        If Not upscale_path.Text = "" Then
            Dim deletedCount = Await clear_folders(upscale_path.Text)
        End If
        clear_upscale.Enabled = True
        clear_temp.Enabled = True

    End Sub
    Private Sub cpu_limit_check_CheckedChanged(sender As Object, e As EventArgs) Handles cpu_limit_check.CheckedChanged
        If cpu_limit_check.Checked = True Then
            cpu_limit.Enabled = True
        Else
            cpu_limit.Enabled = False
        End If
    End Sub

    Private Sub save_file_path_Click(sender As Object, e As EventArgs) Handles save_file_path.Click
        save_file_paths()
    End Sub

    Private Sub clear_paths_Click(sender As Object, e As EventArgs) Handles clear_paths.Click
        clear_file_paths()
    End Sub

    Private Sub show_steps_Click(sender As Object, e As EventArgs) Handles show_steps.Click
        '   Dim filePath As String = Path.Combine(myAppFolder, "app_crashhandler.txt")
        Dim appDataPath As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)
        Dim myAppFolder As String = Path.Combine(appDataPath, "Upscaler")

        ' Open the folder using the specified application
        Process.Start(myAppFolder)

    End Sub

    Private Sub clear_processed_Click(sender As Object, e As EventArgs) Handles clear_processed.Click
        clear_crash_step()
    End Sub
End Class
