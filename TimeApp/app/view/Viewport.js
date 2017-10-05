Ext.define("TrainTimetableApp.view.Viewport", {
    extend: "Ext.container.Viewport",
    requires: ["TrainTimetableApp.view.TimetableTreeGrid",
        "TrainTimetableApp.view.TimetableForm",
        "TrainTimetableApp.view.StationGrid"
    ],
    initComponent: function () {

        this.layout = {
            columns: 2,
            type: "table"
        };

        this.items = [{
            xtype: "TimetableTreeGrid",
            colspan: 2,
            width: "1900px",
            style: "padding:10px 10px 10px 10px"
        },
        {
            xtype: "TimetableForm",
            width: "600px"
        },
        {
            xtype: "StationGrid",
            width: "1285px",
            height: "400px",
            style: "margin-top:20px"
        }

        ];

        this.callParent(arguments);
    }
});