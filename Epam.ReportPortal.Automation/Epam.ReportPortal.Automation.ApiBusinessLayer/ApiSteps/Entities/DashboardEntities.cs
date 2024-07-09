using Newtonsoft.Json;

namespace Epam.ReportPortal.Automation.ApiBusinessLayer.ApiSteps.Entities;

public class DashboardResponseEntities
{
    public class Dashboard
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("owner")]
        public string Owner { get; set; }
        [JsonProperty("widgets")]
        public List<Widget> Widgets { get; set; }
    }

    public class Page
    {
        [JsonProperty("number")]
        public int Number { get; set; }
        [JsonProperty("size")]
        public int Size { get; set; }
        [JsonProperty("totalElements")]
        public int TotalElements { get; set; }
        [JsonProperty("totalPages")]
        public int TotalPages { get; set; }
    }

    public class ResponseBody
    {
        [JsonProperty("content")]
        public List<Dashboard> Dashboards { get; set; }
        [JsonProperty("page")]
        public Page page { get; set; }
    }

    public class Widget
    {
        public string widgetName { get; set; }
        public int widgetId { get; set; }
        public string widgetType { get; set; }
        public WidgetSize widgetSize { get; set; }
        public WidgetPosition widgetPosition { get; set; }
        public WidgetOptions widgetOptions { get; set; }
    }

    public class WidgetOptions
    {
        public bool zoom { get; set; }
        public string timeline { get; set; }
        public string viewMode { get; set; }
    }

    public class WidgetPosition
    {
        public int positionX { get; set; }
        public int positionY { get; set; }
    }

    public class WidgetSize
    {
        public int width { get; set; }
        public int height { get; set; }
    }

    public class Message
    {
        [JsonProperty("message")]
        public string Value { get; set; }
    }

    public class Id
    {
        [JsonProperty("id")]
        public int Value { get; set; }
    }
}