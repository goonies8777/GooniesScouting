// See https://aka.ms/new-console-template for more information
using GooniesScouting.Business.Model;
using GooniesScouting.Business.Services;

OrangeAllianceService oaService = new OrangeAllianceService();
IEnumerable<FtcEvent> ftcEvents = oaService.GetEvents();

foreach(FtcEvent item in ftcEvents)
{
    Console.WriteLine("{0} - {1}", item.Event_Code, item.Event_Name);
}
