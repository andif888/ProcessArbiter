:: $URL: http://svn.dev.s-inn.de/svn/repos001/projects/fs.processpriorityobserver/trunk/ProcessPriorityObserverService/UninstallPPOS.cmd $
:: $Author: andi $
:: $Date: 2009-06-01 01:58:31 +0200 (Mo, 01 Jun 2009) $
:: $Rev: 106 $
:: $Id: UninstallPPOS.cmd 106 2009-05-31 23:58:31Z andi $

sc stop ProcessPriorityObserverService
"C:\WINDOWS\Microsoft.NET\Framework\v2.0.50727\InstallUtil.exe" /u "C:\Program Files\PPOS\ProcessPriorityObserverService.exe"
rd /S /Q "C:\Program Files\PPOS"
