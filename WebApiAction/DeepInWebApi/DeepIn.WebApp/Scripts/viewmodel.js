function ViewModel() {
    self = this;
    self.contacts = ko.observableArray(); //当前联系人列表
    self.contact = ko.observable();       //当前编辑联系人

    //获取当前联系人列表
    self.load = function () {
        $.ajax({
            url: "http://localhost:3742/api/v10/contracts",
            type: "GET",
            success: function (result) {
                self.contacts(result);
            },
            error: function ()
            {
                alert("failed");
            }
        });
    };

    //弹出编辑联系人对话框
    self.showDialog = function (data) {
        //通过Id判断"添加/修改"操作
        if (!data.Id) {
            data = { ID: "", Name: "", PhoneNo: "", EmailAddress: "", Address: "" }
        }
        self.contact(data);
        $(".modal").modal('show');
    };

    //调用Web API添加/修改联系人信息
    self.save = function () {
        $(".modal").modal('hide');
        if (self.contact().Id) {
            $.ajax({
                url: "http://localhost:3742/api/v10/contracts/" + self.contact.Id,
                type: "PUT",
                data: self.contact(),
                success: function () {
                    self.load();
                }
            });
        }
        else {
            $.ajax({
                url: "http://localhost:3742/api/v10/contracts",
                type: "POST",
                data: self.contact(),
                success: function () {
                    self.load();
                }
            });
        }
    };

    //删除现有联系人
    self.delete = function (data) {
        $.ajax({
            url: "http://localhost:3742/api/v10/contracts/" + data.Id,
            type: "DELETE",
            success: function () {
                self.load();
            }
        });
    };

    self.load();
}

$(function () {
    ko.applyBindings(new ViewModel());
});