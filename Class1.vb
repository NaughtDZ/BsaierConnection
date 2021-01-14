Imports System.Drawing
Public Class BsaierSoomthConnection
    ''' <summary>
    ''' 普通平滑模式
    ''' </summary>
    ''' <param name="p1">第一个点</param>
    ''' <param name="p2">第二个点</param>
    ''' <returns>两个点之间平滑用的贝塞尔控制点组ps(0),ps(1)</returns>
    Public Function SoomthControlPoint(ByVal p1 As PointF, ByVal p2 As PointF)
        Dim ps1 As PointF, ps2 As PointF
        ps1.X = (p1.X + p2.X) / 2
        ps1.Y = p1.Y
        ps2.X = (p1.X + p2.X) / 2
        ps2.Y = p2.Y
        Dim ps() As PointF = {ps1, ps2}
        Return ps
    End Function
    ''' <summary>
    ''' 去掉首尾的4点平滑模式
    ''' </summary>
    ''' <param name="p1">第一个点</param>
    ''' <param name="p2">第二个点</param>
    ''' <param name="p3">第三个点</param>
    ''' <param name="p4">第四个点</param>
    ''' <returns>第一第二点之间的两个平滑用贝塞尔控制点组ps(0),ps(1)</returns>
    Public Function SoomthControlBy4(ByVal p1 As PointF, ByVal p2 As PointF, ByVal p3 As PointF, ByVal p4 As PointF)
        Dim ps1 As PointF, ps2 As PointF
        ps1.X = p2.X + (p3.X - p1.X) / 4
        ps1.Y = p2.Y + (p3.Y - p1.Y) / 4
        ps2.X = p3.X - (p4.X - p2.X) / 4
        ps2.Y = p3.Y - (p4.Y - p2.Y) / 4
        Dim ps() As PointF = {ps1, ps2}
        Return ps
    End Function
    ''' <summary>
    ''' 首尾的4点平滑模式
    ''' </summary>
    ''' <param name="p1">第一个点</param>
    ''' <param name="p2">第二个点</param>
    ''' <param name="p3">第三个点</param>
    ''' <param name="p4">第四个点</param>
    ''' <param name="headORtail">True为首点，p1即为第一个点，Flase为尾点，p4为最后一个点</param>
    ''' <returns>头与下一个或尾与上一个的两个平滑用贝塞尔控制点组ps(0),ps(1)</returns>
    Public Function SoomthControlBy4OnEdge(ByVal p1 As PointF, ByVal p2 As PointF, ByVal p3 As PointF, ByVal p4 As PointF, ByVal headORtail As Boolean)
        Dim ps1 As PointF, ps2 As PointF
        If headORtail = True Then
            ps1.X = p1.X + (p2.X - p1.X) / 4
            ps1.Y = p1.Y + (p2.Y - p1.Y) / 4
            ps2.X = p3.X - (p4.X - p2.X) / 4
            ps2.Y = p3.Y - (p4.Y - p2.Y) / 4
        Else
            ps1.X = p2.X + (p3.X - p1.X) / 4
            ps1.Y = p2.Y + (p3.Y - p1.Y) / 4
            ps2.X = p4.X - (p4.X - p3.X) / 4
            ps2.Y = p4.Y - (p4.Y - p3.Y) / 4
        End If
        Dim ps() As PointF = {ps1, ps2}
        Return ps
    End Function
End Class
