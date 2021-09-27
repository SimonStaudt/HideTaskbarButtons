using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

public class WinDlls
{
    #region findwindow
    /// <summary>
    ///     Retrieves a handle to the top-level window whose class name and window name match the specified strings. This
    ///     function does not search child windows. This function does not perform a case-sensitive search. To search child
    ///     windows, beginning with a specified child window, use the
    ///     <see cref="!:https://msdn.microsoft.com/en-us/library/windows/desktop/ms633500%28v=vs.85%29.aspx">FindWindowEx</see>
    ///     function.
    ///     <para>
    ///     Go to https://msdn.microsoft.com/en-us/library/windows/desktop/ms633499%28v=vs.85%29.aspx for FindWindow
    ///     information or https://msdn.microsoft.com/en-us/library/windows/desktop/ms633500%28v=vs.85%29.aspx for
    ///     FindWindowEx
    ///     </para>
    /// </summary>
    /// <param name="lpClassName">
    ///     C++ ( lpClassName [in, optional]. Type: LPCTSTR )<br />The class name or a class atom created by a previous call to
    ///     the RegisterClass or RegisterClassEx function. The atom must be in the low-order word of lpClassName; the
    ///     high-order word must be zero.
    ///     <para>
    ///     If lpClassName points to a string, it specifies the window class name. The class name can be any name
    ///     registered with RegisterClass or RegisterClassEx, or any of the predefined control-class names.
    ///     </para>
    ///     <para>If lpClassName is NULL, it finds any window whose title matches the lpWindowName parameter.</para>
    /// </param>
    /// <param name="lpWindowName">
    ///     C++ ( lpWindowName [in, optional]. Type: LPCTSTR )<br />The window name (the window's
    ///     title). If this parameter is NULL, all window names match.
    /// </param>
    /// <returns>
    ///     C++ ( Type: HWND )<br />If the function succeeds, the return value is a handle to the window that has the
    ///     specified class name and window name. If the function fails, the return value is NULL.
    ///     <para>To get extended error information, call GetLastError.</para>
    /// </returns>
    /// <remarks>
    ///     If the lpWindowName parameter is not NULL, FindWindow calls the <see cref="M:GetWindowText" /> function to
    ///     retrieve the window name for comparison. For a description of a potential problem that can arise, see the Remarks
    ///     for <see cref="M:GetWindowText" />.
    /// </remarks>
    // For Windows Mobile, replace user32.dll with coredll.dll
    [DllImport("user32.dll", SetLastError = true)]
    public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

    // Find window by Caption only. Note you must pass IntPtr.Zero as the first parameter.

    [DllImport("user32.dll", EntryPoint = "FindWindow", SetLastError = true)]
    public static extern IntPtr FindWindowByCaption(IntPtr ZeroOnly, string lpWindowName);

    // You can also call FindWindow(default(string), lpWindowName) or FindWindow((string)null, lpWindowName)
    #endregion

    [DllImport("user32.dll", SetLastError = true)]
    public static extern IntPtr FindWindowEx(IntPtr parentHandle, IntPtr hWndChildAfter, string className, string windowTitle);

    [DllImport("user32.dll")]
    public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);


    [DllImport("user32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool IsWindowVisible(IntPtr hWnd);
}
