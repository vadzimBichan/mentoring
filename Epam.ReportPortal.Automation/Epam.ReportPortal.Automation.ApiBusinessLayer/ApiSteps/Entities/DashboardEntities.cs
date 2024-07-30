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
        public Page Page { get; set; }
    }

    public class Widget
    {
        [JsonProperty("widgetName")]
        public string Name { get; set; }
        [JsonProperty("widgetType")]
        public string Type { get; set; }
        [JsonProperty("widgetId")]
        public int Id { get; set; }
        [JsonProperty("widgetSize")]
        public WidgetSize Size { get; set; }
        [JsonProperty("widgetPosition")]
        public WidgetPosition Position { get; set; }
        [JsonProperty("widgetOptions")]
        public WidgetOptions Options { get; set; }
    }

    public class WidgetOptions
    {
        [JsonProperty("zoom")]
        public bool Zoom { get; set; }
        [JsonProperty("timeline")]
        public string Timeline { get; set; }
        [JsonProperty("viewMode")]
        public string ViewMode { get; set; }
    }

    public class WidgetPosition
    {
        [JsonProperty("positionX")]
        public int PositionX { get; set; }
        [JsonProperty("positionY")]
        public int PositionY { get; set; }
    }

    public class WidgetSize
    {
        [JsonProperty("width")]
        public int Width { get; set; }
        [JsonProperty("height")]
        public int Height { get; set; }
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