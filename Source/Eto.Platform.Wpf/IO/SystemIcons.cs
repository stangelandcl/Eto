using System;
using sd = System.Drawing;
using Eto.Drawing;
using Eto.IO;
using Eto.Platform.Wpf.Drawing;
using sw = System.Windows;
using swm = System.Windows.Media;
using swmi = System.Windows.Media.Imaging;
using swi = System.Windows.Interop;

namespace Eto.Platform.Wpf.IO
{
	public class SystemIconsHandler : WidgetHandler<SystemIcons>, ISystemIcons
	{
		public Icon GetFileIcon (string fileName, Eto.IO.IconSize size)
		{
			ShellIcon.IconSize iconSize;
			switch (size) {
			case IconSize.Large:
				iconSize = ShellIcon.IconSize.Large;
				break;
			case IconSize.Small:
				iconSize = ShellIcon.IconSize.Small;
				break;
			default:
				throw new NotSupportedException ();
			}

			using (var icon = ShellIcon.GetFileIcon (fileName, iconSize, false)) {
				return new Icon (Widget.Generator, new IconHandler (icon));
			}
		}

		public Icon GetStaticIcon (Eto.IO.StaticIconType type, Eto.IO.IconSize size)
		{
			ShellIcon.IconSize iconSize;
			switch (size) {
			case IconSize.Large:
				iconSize = ShellIcon.IconSize.Large;
				break;
			case IconSize.Small:
				iconSize = ShellIcon.IconSize.Small;
				break;
			default:
				throw new NotSupportedException ();
			}

			ShellIcon.FolderType folderType;
			switch (type) {
			case StaticIconType.OpenDirectory:
				folderType = ShellIcon.FolderType.Open;
				break;
			case StaticIconType.CloseDirectory:
				folderType = ShellIcon.FolderType.Closed;
				break;
			default:
				throw new NotSupportedException ();
			}

			using (var icon = ShellIcon.GetFolderIcon (iconSize, folderType)) {
				return new Icon (Widget.Generator, new IconHandler (icon));
			}
		}
	}
}
