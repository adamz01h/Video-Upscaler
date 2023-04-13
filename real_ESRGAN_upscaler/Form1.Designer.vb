<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.output_scale = New System.Windows.Forms.ComboBox()
        Me.downmix_audio = New System.Windows.Forms.CheckBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.download_ffmepg = New System.Windows.Forms.Button()
        Me.use_ffmepg_system = New System.Windows.Forms.CheckBox()
        Me.br_ffmpeg = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.ffmpeg_path = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.output_path = New System.Windows.Forms.TextBox()
        Me.br_output = New System.Windows.Forms.Button()
        Me.src_path = New System.Windows.Forms.TextBox()
        Me.br_src = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.download_real = New System.Windows.Forms.Button()
        Me.clear_temp = New System.Windows.Forms.Button()
        Me.clear_upscale = New System.Windows.Forms.Button()
        Me.GroupBox9 = New System.Windows.Forms.GroupBox()
        Me.clear_upscale_box = New System.Windows.Forms.CheckBox()
        Me.clear_temp_box = New System.Windows.Forms.CheckBox()
        Me.br_esrgan = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.esrgan_vulkan_path = New System.Windows.Forms.TextBox()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.model = New System.Windows.Forms.ComboBox()
        Me.img_format_box = New System.Windows.Forms.GroupBox()
        Me.img_3 = New System.Windows.Forms.RadioButton()
        Me.img_2 = New System.Windows.Forms.RadioButton()
        Me.img_1 = New System.Windows.Forms.RadioButton()
        Me.br_upscale = New System.Windows.Forms.Button()
        Me.br_temp = New System.Windows.Forms.Button()
        Me.upscale_path = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.temp_path = New System.Windows.Forms.TextBox()
        Me.upscale_box = New System.Windows.Forms.GroupBox()
        Me.scale_2 = New System.Windows.Forms.RadioButton()
        Me.scale_4 = New System.Windows.Forms.RadioButton()
        Me.scale_3 = New System.Windows.Forms.RadioButton()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.profile_path = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.load_profile = New System.Windows.Forms.Button()
        Me.save_profile = New System.Windows.Forms.Button()
        Me.GroupBox8 = New System.Windows.Forms.GroupBox()
        Me.msg_info = New System.Windows.Forms.Label()
        Me.GroupBox10 = New System.Windows.Forms.GroupBox()
        Me.st_5 = New System.Windows.Forms.RadioButton()
        Me.st_4 = New System.Windows.Forms.RadioButton()
        Me.go_btn = New System.Windows.Forms.Button()
        Me.st_3 = New System.Windows.Forms.RadioButton()
        Me.st_2 = New System.Windows.Forms.RadioButton()
        Me.st_1 = New System.Windows.Forms.RadioButton()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox9.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.img_format_box.SuspendLayout()
        Me.upscale_box.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        Me.GroupBox8.SuspendLayout()
        Me.GroupBox10.SuspendLayout()
        Me.SuspendLayout()
        '
        'output_scale
        '
        Me.output_scale.FormattingEnabled = True
        Me.output_scale.Items.AddRange(New Object() {"1280 x 720 (720p)", "1920 x 1080 (1080p)", "2048 x 1080 (2K)", "4096 x 2160 (4k)"})
        Me.output_scale.Location = New System.Drawing.Point(81, 22)
        Me.output_scale.Name = "output_scale"
        Me.output_scale.Size = New System.Drawing.Size(137, 21)
        Me.output_scale.TabIndex = 4
        '
        'downmix_audio
        '
        Me.downmix_audio.AutoSize = True
        Me.downmix_audio.Location = New System.Drawing.Point(233, 24)
        Me.downmix_audio.Name = "downmix_audio"
        Me.downmix_audio.Size = New System.Drawing.Size(145, 17)
        Me.downmix_audio.TabIndex = 5
        Me.downmix_audio.Text = "Downmix Audio to Stereo"
        Me.downmix_audio.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.download_ffmepg)
        Me.GroupBox1.Controls.Add(Me.use_ffmepg_system)
        Me.GroupBox1.Controls.Add(Me.br_ffmpeg)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.ffmpeg_path)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.output_scale)
        Me.GroupBox1.Controls.Add(Me.downmix_audio)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 163)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(776, 85)
        Me.GroupBox1.TabIndex = 6
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "FFmpeg Options"
        '
        'download_ffmepg
        '
        Me.download_ffmepg.Location = New System.Drawing.Point(685, 54)
        Me.download_ffmepg.Name = "download_ffmepg"
        Me.download_ffmepg.Size = New System.Drawing.Size(75, 23)
        Me.download_ffmepg.TabIndex = 11
        Me.download_ffmepg.Text = "Download"
        Me.download_ffmepg.UseVisualStyleBackColor = True
        '
        'use_ffmepg_system
        '
        Me.use_ffmepg_system.AutoSize = True
        Me.use_ffmepg_system.Location = New System.Drawing.Point(572, 58)
        Me.use_ffmepg_system.Name = "use_ffmepg_system"
        Me.use_ffmepg_system.Size = New System.Drawing.Size(107, 17)
        Me.use_ffmepg_system.TabIndex = 10
        Me.use_ffmepg_system.Text = "Use System Path"
        Me.use_ffmepg_system.UseVisualStyleBackColor = True
        '
        'br_ffmpeg
        '
        Me.br_ffmpeg.Location = New System.Drawing.Point(491, 54)
        Me.br_ffmpeg.Name = "br_ffmpeg"
        Me.br_ffmpeg.Size = New System.Drawing.Size(75, 23)
        Me.br_ffmpeg.TabIndex = 9
        Me.br_ffmpeg.Text = "Browse..."
        Me.br_ffmpeg.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(9, 59)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(82, 13)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = "Path to FFmpeg"
        '
        'ffmpeg_path
        '
        Me.ffmpeg_path.Location = New System.Drawing.Point(97, 56)
        Me.ffmpeg_path.Name = "ffmpeg_path"
        Me.ffmpeg_path.Size = New System.Drawing.Size(388, 20)
        Me.ffmpeg_path.TabIndex = 7
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(69, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Output Scale"
        '
        'output_path
        '
        Me.output_path.Location = New System.Drawing.Point(75, 43)
        Me.output_path.Name = "output_path"
        Me.output_path.Size = New System.Drawing.Size(604, 20)
        Me.output_path.TabIndex = 2
        '
        'br_output
        '
        Me.br_output.Location = New System.Drawing.Point(685, 41)
        Me.br_output.Name = "br_output"
        Me.br_output.Size = New System.Drawing.Size(75, 23)
        Me.br_output.TabIndex = 3
        Me.br_output.Text = "Browse..."
        Me.br_output.UseVisualStyleBackColor = True
        '
        'src_path
        '
        Me.src_path.Location = New System.Drawing.Point(75, 18)
        Me.src_path.Name = "src_path"
        Me.src_path.Size = New System.Drawing.Size(604, 20)
        Me.src_path.TabIndex = 1
        '
        'br_src
        '
        Me.br_src.Location = New System.Drawing.Point(685, 16)
        Me.br_src.Name = "br_src"
        Me.br_src.Size = New System.Drawing.Size(75, 23)
        Me.br_src.TabIndex = 0
        Me.br_src.Text = "Browse..."
        Me.br_src.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 21)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(60, 13)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Source File"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(8, 46)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(58, 13)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Output File"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Controls.Add(Me.br_src)
        Me.GroupBox3.Controls.Add(Me.src_path)
        Me.GroupBox3.Controls.Add(Me.output_path)
        Me.GroupBox3.Controls.Add(Me.br_output)
        Me.GroupBox3.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(776, 80)
        Me.GroupBox3.TabIndex = 9
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Video Files"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.download_real)
        Me.GroupBox4.Controls.Add(Me.clear_temp)
        Me.GroupBox4.Controls.Add(Me.clear_upscale)
        Me.GroupBox4.Controls.Add(Me.GroupBox9)
        Me.GroupBox4.Controls.Add(Me.br_esrgan)
        Me.GroupBox4.Controls.Add(Me.Label7)
        Me.GroupBox4.Controls.Add(Me.esrgan_vulkan_path)
        Me.GroupBox4.Controls.Add(Me.GroupBox6)
        Me.GroupBox4.Controls.Add(Me.img_format_box)
        Me.GroupBox4.Controls.Add(Me.br_upscale)
        Me.GroupBox4.Controls.Add(Me.br_temp)
        Me.GroupBox4.Controls.Add(Me.upscale_path)
        Me.GroupBox4.Controls.Add(Me.Label5)
        Me.GroupBox4.Controls.Add(Me.Label4)
        Me.GroupBox4.Controls.Add(Me.temp_path)
        Me.GroupBox4.Controls.Add(Me.upscale_box)
        Me.GroupBox4.Location = New System.Drawing.Point(12, 256)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(776, 185)
        Me.GroupBox4.TabIndex = 10
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Real-ESRGAN Options"
        '
        'download_real
        '
        Me.download_real.Location = New System.Drawing.Point(685, 100)
        Me.download_real.Name = "download_real"
        Me.download_real.Size = New System.Drawing.Size(75, 23)
        Me.download_real.TabIndex = 30
        Me.download_real.Text = "Download"
        Me.download_real.UseVisualStyleBackColor = True
        '
        'clear_temp
        '
        Me.clear_temp.Location = New System.Drawing.Point(685, 125)
        Me.clear_temp.Name = "clear_temp"
        Me.clear_temp.Size = New System.Drawing.Size(75, 23)
        Me.clear_temp.TabIndex = 2
        Me.clear_temp.Text = "Clear Folder"
        Me.clear_temp.UseVisualStyleBackColor = True
        '
        'clear_upscale
        '
        Me.clear_upscale.Location = New System.Drawing.Point(685, 150)
        Me.clear_upscale.Name = "clear_upscale"
        Me.clear_upscale.Size = New System.Drawing.Size(75, 23)
        Me.clear_upscale.TabIndex = 3
        Me.clear_upscale.Text = "Clear Folder"
        Me.clear_upscale.UseVisualStyleBackColor = True
        '
        'GroupBox9
        '
        Me.GroupBox9.Controls.Add(Me.clear_upscale_box)
        Me.GroupBox9.Controls.Add(Me.clear_temp_box)
        Me.GroupBox9.Location = New System.Drawing.Point(493, 25)
        Me.GroupBox9.Name = "GroupBox9"
        Me.GroupBox9.Size = New System.Drawing.Size(186, 51)
        Me.GroupBox9.TabIndex = 29
        Me.GroupBox9.TabStop = False
        Me.GroupBox9.Text = "Clear Frames on complete"
        '
        'clear_upscale_box
        '
        Me.clear_upscale_box.AutoSize = True
        Me.clear_upscale_box.Location = New System.Drawing.Point(65, 21)
        Me.clear_upscale_box.Name = "clear_upscale_box"
        Me.clear_upscale_box.Size = New System.Drawing.Size(71, 17)
        Me.clear_upscale_box.TabIndex = 1
        Me.clear_upscale_box.Text = "Upscaled"
        Me.clear_upscale_box.UseVisualStyleBackColor = True
        '
        'clear_temp_box
        '
        Me.clear_temp_box.AutoSize = True
        Me.clear_temp_box.Location = New System.Drawing.Point(6, 21)
        Me.clear_temp_box.Name = "clear_temp_box"
        Me.clear_temp_box.Size = New System.Drawing.Size(53, 17)
        Me.clear_temp_box.TabIndex = 0
        Me.clear_temp_box.Text = "Temp"
        Me.clear_temp_box.UseVisualStyleBackColor = True
        '
        'br_esrgan
        '
        Me.br_esrgan.Location = New System.Drawing.Point(604, 100)
        Me.br_esrgan.Name = "br_esrgan"
        Me.br_esrgan.Size = New System.Drawing.Size(75, 23)
        Me.br_esrgan.TabIndex = 28
        Me.br_esrgan.Text = "Browse..."
        Me.br_esrgan.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(12, 105)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(149, 13)
        Me.Label7.TabIndex = 27
        Me.Label7.Text = "Path to Real ESRGAN vulkan"
        '
        'esrgan_vulkan_path
        '
        Me.esrgan_vulkan_path.Location = New System.Drawing.Point(165, 100)
        Me.esrgan_vulkan_path.Name = "esrgan_vulkan_path"
        Me.esrgan_vulkan_path.Size = New System.Drawing.Size(433, 20)
        Me.esrgan_vulkan_path.TabIndex = 26
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.model)
        Me.GroupBox6.Location = New System.Drawing.Point(315, 25)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(170, 51)
        Me.GroupBox6.TabIndex = 25
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Model"
        '
        'model
        '
        Me.model.FormattingEnabled = True
        Me.model.Items.AddRange(New Object() {"realesr-animevideov3", "realesrgan-x4plus", "realesrgan-x4plus-anime", "realesrnet-x4plus"})
        Me.model.Location = New System.Drawing.Point(7, 19)
        Me.model.Name = "model"
        Me.model.Size = New System.Drawing.Size(151, 21)
        Me.model.TabIndex = 0
        '
        'img_format_box
        '
        Me.img_format_box.Controls.Add(Me.img_3)
        Me.img_format_box.Controls.Add(Me.img_2)
        Me.img_format_box.Controls.Add(Me.img_1)
        Me.img_format_box.Location = New System.Drawing.Point(158, 25)
        Me.img_format_box.Name = "img_format_box"
        Me.img_format_box.Size = New System.Drawing.Size(151, 51)
        Me.img_format_box.TabIndex = 24
        Me.img_format_box.TabStop = False
        Me.img_format_box.Text = "Image Format"
        '
        'img_3
        '
        Me.img_3.AutoSize = True
        Me.img_3.Location = New System.Drawing.Point(96, 19)
        Me.img_3.Name = "img_3"
        Me.img_3.Size = New System.Drawing.Size(51, 17)
        Me.img_3.TabIndex = 2
        Me.img_3.TabStop = True
        Me.img_3.Text = "webp"
        Me.img_3.UseVisualStyleBackColor = True
        '
        'img_2
        '
        Me.img_2.AutoSize = True
        Me.img_2.Location = New System.Drawing.Point(53, 19)
        Me.img_2.Name = "img_2"
        Me.img_2.Size = New System.Drawing.Size(43, 17)
        Me.img_2.TabIndex = 1
        Me.img_2.TabStop = True
        Me.img_2.Text = "png"
        Me.img_2.UseVisualStyleBackColor = True
        '
        'img_1
        '
        Me.img_1.AutoSize = True
        Me.img_1.Location = New System.Drawing.Point(7, 19)
        Me.img_1.Name = "img_1"
        Me.img_1.Size = New System.Drawing.Size(39, 17)
        Me.img_1.TabIndex = 0
        Me.img_1.TabStop = True
        Me.img_1.Text = "jpg"
        Me.img_1.UseVisualStyleBackColor = True
        '
        'br_upscale
        '
        Me.br_upscale.Location = New System.Drawing.Point(604, 150)
        Me.br_upscale.Name = "br_upscale"
        Me.br_upscale.Size = New System.Drawing.Size(75, 23)
        Me.br_upscale.TabIndex = 23
        Me.br_upscale.Text = "Browse..."
        Me.br_upscale.UseVisualStyleBackColor = True
        '
        'br_temp
        '
        Me.br_temp.Location = New System.Drawing.Point(604, 125)
        Me.br_temp.Name = "br_temp"
        Me.br_temp.Size = New System.Drawing.Size(75, 23)
        Me.br_temp.TabIndex = 22
        Me.br_temp.Text = "Browse..."
        Me.br_temp.UseVisualStyleBackColor = True
        '
        'upscale_path
        '
        Me.upscale_path.Location = New System.Drawing.Point(106, 152)
        Me.upscale_path.Name = "upscale_path"
        Me.upscale_path.Size = New System.Drawing.Size(492, 20)
        Me.upscale_path.TabIndex = 21
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 155)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(83, 13)
        Me.Label5.TabIndex = 20
        Me.Label5.Text = "Upscale Frames"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 129)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(71, 13)
        Me.Label4.TabIndex = 19
        Me.Label4.Text = "Temp Frames"
        '
        'temp_path
        '
        Me.temp_path.Location = New System.Drawing.Point(106, 126)
        Me.temp_path.Name = "temp_path"
        Me.temp_path.Size = New System.Drawing.Size(492, 20)
        Me.temp_path.TabIndex = 18
        '
        'upscale_box
        '
        Me.upscale_box.Controls.Add(Me.scale_2)
        Me.upscale_box.Controls.Add(Me.scale_4)
        Me.upscale_box.Controls.Add(Me.scale_3)
        Me.upscale_box.Location = New System.Drawing.Point(15, 25)
        Me.upscale_box.Name = "upscale_box"
        Me.upscale_box.Size = New System.Drawing.Size(137, 51)
        Me.upscale_box.TabIndex = 12
        Me.upscale_box.TabStop = False
        Me.upscale_box.Text = "Upscale"
        '
        'scale_2
        '
        Me.scale_2.AutoSize = True
        Me.scale_2.Location = New System.Drawing.Point(6, 19)
        Me.scale_2.Name = "scale_2"
        Me.scale_2.Size = New System.Drawing.Size(36, 17)
        Me.scale_2.TabIndex = 8
        Me.scale_2.TabStop = True
        Me.scale_2.Text = "2x"
        Me.scale_2.UseVisualStyleBackColor = True
        '
        'scale_4
        '
        Me.scale_4.AutoSize = True
        Me.scale_4.Location = New System.Drawing.Point(91, 19)
        Me.scale_4.Name = "scale_4"
        Me.scale_4.Size = New System.Drawing.Size(36, 17)
        Me.scale_4.TabIndex = 10
        Me.scale_4.TabStop = True
        Me.scale_4.Text = "4x"
        Me.scale_4.UseVisualStyleBackColor = True
        '
        'scale_3
        '
        Me.scale_3.AutoSize = True
        Me.scale_3.Location = New System.Drawing.Point(48, 19)
        Me.scale_3.Name = "scale_3"
        Me.scale_3.Size = New System.Drawing.Size(36, 17)
        Me.scale_3.TabIndex = 9
        Me.scale_3.TabStop = True
        Me.scale_3.Text = "3x"
        Me.scale_3.UseVisualStyleBackColor = True
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.profile_path)
        Me.GroupBox7.Controls.Add(Me.Label8)
        Me.GroupBox7.Controls.Add(Me.load_profile)
        Me.GroupBox7.Controls.Add(Me.save_profile)
        Me.GroupBox7.Location = New System.Drawing.Point(12, 98)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(776, 59)
        Me.GroupBox7.TabIndex = 11
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "Profiles"
        '
        'profile_path
        '
        Me.profile_path.Location = New System.Drawing.Point(55, 21)
        Me.profile_path.Name = "profile_path"
        Me.profile_path.Size = New System.Drawing.Size(543, 20)
        Me.profile_path.TabIndex = 3
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(12, 24)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(36, 13)
        Me.Label8.TabIndex = 2
        Me.Label8.Text = "Profile"
        '
        'load_profile
        '
        Me.load_profile.Location = New System.Drawing.Point(604, 19)
        Me.load_profile.Name = "load_profile"
        Me.load_profile.Size = New System.Drawing.Size(75, 23)
        Me.load_profile.TabIndex = 1
        Me.load_profile.Text = "Load Profile"
        Me.load_profile.UseVisualStyleBackColor = True
        '
        'save_profile
        '
        Me.save_profile.Location = New System.Drawing.Point(685, 19)
        Me.save_profile.Name = "save_profile"
        Me.save_profile.Size = New System.Drawing.Size(75, 23)
        Me.save_profile.TabIndex = 0
        Me.save_profile.Text = "Save Profile"
        Me.save_profile.UseVisualStyleBackColor = True
        '
        'GroupBox8
        '
        Me.GroupBox8.Controls.Add(Me.msg_info)
        Me.GroupBox8.Controls.Add(Me.GroupBox10)
        Me.GroupBox8.Location = New System.Drawing.Point(12, 447)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Size = New System.Drawing.Size(776, 109)
        Me.GroupBox8.TabIndex = 12
        Me.GroupBox8.TabStop = False
        Me.GroupBox8.Text = "Controls"
        '
        'msg_info
        '
        Me.msg_info.AutoSize = True
        Me.msg_info.Location = New System.Drawing.Point(12, 80)
        Me.msg_info.Name = "msg_info"
        Me.msg_info.Size = New System.Drawing.Size(87, 13)
        Me.msg_info.TabIndex = 5
        Me.msg_info.Text = "Status messsage"
        '
        'GroupBox10
        '
        Me.GroupBox10.Controls.Add(Me.st_5)
        Me.GroupBox10.Controls.Add(Me.st_4)
        Me.GroupBox10.Controls.Add(Me.go_btn)
        Me.GroupBox10.Controls.Add(Me.st_3)
        Me.GroupBox10.Controls.Add(Me.st_2)
        Me.GroupBox10.Controls.Add(Me.st_1)
        Me.GroupBox10.Location = New System.Drawing.Point(6, 19)
        Me.GroupBox10.Name = "GroupBox10"
        Me.GroupBox10.Size = New System.Drawing.Size(764, 48)
        Me.GroupBox10.TabIndex = 3
        Me.GroupBox10.TabStop = False
        Me.GroupBox10.Text = "Status"
        '
        'st_5
        '
        Me.st_5.AutoSize = True
        Me.st_5.Location = New System.Drawing.Point(489, 22)
        Me.st_5.Name = "st_5"
        Me.st_5.Size = New System.Drawing.Size(69, 17)
        Me.st_5.TabIndex = 4
        Me.st_5.TabStop = True
        Me.st_5.Text = "Complete"
        Me.st_5.UseVisualStyleBackColor = True
        '
        'st_4
        '
        Me.st_4.AutoSize = True
        Me.st_4.Location = New System.Drawing.Point(389, 22)
        Me.st_4.Name = "st_4"
        Me.st_4.Size = New System.Drawing.Size(94, 17)
        Me.st_4.TabIndex = 3
        Me.st_4.TabStop = True
        Me.st_4.Text = "Creating Video"
        Me.st_4.UseVisualStyleBackColor = True
        '
        'go_btn
        '
        Me.go_btn.Location = New System.Drawing.Point(6, 19)
        Me.go_btn.Name = "go_btn"
        Me.go_btn.Size = New System.Drawing.Size(75, 23)
        Me.go_btn.TabIndex = 0
        Me.go_btn.Text = "Go"
        Me.go_btn.UseVisualStyleBackColor = True
        '
        'st_3
        '
        Me.st_3.AutoSize = True
        Me.st_3.Location = New System.Drawing.Point(274, 22)
        Me.st_3.Name = "st_3"
        Me.st_3.Size = New System.Drawing.Size(109, 17)
        Me.st_3.TabIndex = 2
        Me.st_3.TabStop = True
        Me.st_3.Text = "Upscaling Frames"
        Me.st_3.UseVisualStyleBackColor = True
        '
        'st_2
        '
        Me.st_2.AutoSize = True
        Me.st_2.Location = New System.Drawing.Point(174, 22)
        Me.st_2.Name = "st_2"
        Me.st_2.Size = New System.Drawing.Size(98, 17)
        Me.st_2.TabIndex = 1
        Me.st_2.TabStop = True
        Me.st_2.Text = "Ripping Frames"
        Me.st_2.UseVisualStyleBackColor = True
        '
        'st_1
        '
        Me.st_1.AutoSize = True
        Me.st_1.Location = New System.Drawing.Point(91, 22)
        Me.st_1.Name = "st_1"
        Me.st_1.Size = New System.Drawing.Size(77, 17)
        Me.st_1.TabIndex = 0
        Me.st_1.TabStop = True
        Me.st_1.Text = "Prep Video"
        Me.st_1.UseVisualStyleBackColor = True
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 568)
        Me.Controls.Add(Me.GroupBox8)
        Me.Controls.Add(Me.GroupBox7)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form1"
        Me.Text = "Upscaler"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox9.ResumeLayout(False)
        Me.GroupBox9.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        Me.img_format_box.ResumeLayout(False)
        Me.img_format_box.PerformLayout()
        Me.upscale_box.ResumeLayout(False)
        Me.upscale_box.PerformLayout()
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
        Me.GroupBox8.ResumeLayout(False)
        Me.GroupBox8.PerformLayout()
        Me.GroupBox10.ResumeLayout(False)
        Me.GroupBox10.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents output_scale As ComboBox
    Friend WithEvents downmix_audio As CheckBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label1 As Label
    Friend WithEvents use_ffmepg_system As CheckBox
    Friend WithEvents br_ffmpeg As Button
    Friend WithEvents Label6 As Label
    Friend WithEvents ffmpeg_path As TextBox
    Friend WithEvents output_path As TextBox
    Friend WithEvents br_output As Button
    Friend WithEvents src_path As TextBox
    Friend WithEvents br_src As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents GroupBox6 As GroupBox
    Friend WithEvents model As ComboBox
    Friend WithEvents img_format_box As GroupBox
    Friend WithEvents img_3 As RadioButton
    Friend WithEvents img_2 As RadioButton
    Friend WithEvents img_1 As RadioButton
    Friend WithEvents br_upscale As Button
    Friend WithEvents br_temp As Button
    Friend WithEvents upscale_path As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents temp_path As TextBox
    Friend WithEvents upscale_box As GroupBox
    Friend WithEvents scale_2 As RadioButton
    Friend WithEvents scale_4 As RadioButton
    Friend WithEvents scale_3 As RadioButton
    Friend WithEvents br_esrgan As Button
    Friend WithEvents Label7 As Label
    Friend WithEvents esrgan_vulkan_path As TextBox
    Friend WithEvents GroupBox7 As GroupBox
    Friend WithEvents profile_path As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents load_profile As Button
    Friend WithEvents save_profile As Button
    Friend WithEvents GroupBox8 As GroupBox
    Friend WithEvents clear_upscale As Button
    Friend WithEvents clear_temp As Button
    Friend WithEvents go_btn As Button
    Friend WithEvents GroupBox9 As GroupBox
    Friend WithEvents clear_upscale_box As CheckBox
    Friend WithEvents clear_temp_box As CheckBox
    Friend WithEvents msg_info As Label
    Friend WithEvents GroupBox10 As GroupBox
    Friend WithEvents st_5 As RadioButton
    Friend WithEvents st_4 As RadioButton
    Friend WithEvents st_3 As RadioButton
    Friend WithEvents st_2 As RadioButton
    Friend WithEvents st_1 As RadioButton
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents SaveFileDialog1 As SaveFileDialog
    Friend WithEvents FolderBrowserDialog1 As FolderBrowserDialog
    Friend WithEvents download_real As Button
    Friend WithEvents download_ffmepg As Button
    Friend WithEvents Timer1 As Timer
End Class
