$(document).ready(function () {
    function Freelancer(data) {
        this.FreeLancerId = ko.observable(data.FreeLancerId);
        this.Username = ko.observable(data.Username);
        this.Email = ko.observable(data.Email);
        this.PhoneNumber = ko.observable(data.PhoneNumber);
        this.Skillsets = ko.observable(data.Skillsets);
        this.Hobby = ko.observable(data.Hobby);
        this.DateJoined = ko.observable(data.DateJoined);
    }

    function AdminViewModel() {
        var self = this;

        self.freelancers = ko.observableArray([]);
        self.filterFreelancerUserName = ko.observable('');
        self.pageIndex = ko.observable(1);
        self.pageSize = ko.observable(10);
        self.sortField = ko.observable('dateJoined');
        self.sortOrder = ko.observable('desc');
        self.itemsCount = ko.observable(0);
        self.hasMorePages = ko.computed(function () {
            return self.itemsCount() > self.pageIndex() * self.pageSize();
        });

        self.getFreelancerList = function () {
            var filterUsername = self.filterFreelancerUserName();
            var url = `/api/Admin/Freelancer?pageIndex=${self.pageIndex()}&pageSize=${self.pageSize()}&sortField=${self.sortField()}&sortOrder=${self.sortOrder()}&filterFreelancerUserName=${filterUsername}`;

            console.log("Request URL:", url);  

            $.getJSON(url, function (data) {
                console.log("API Response:", data); 

                self.freelancers.removeAll();
                $.each(data.data.FreelancerList, function (index, item) {
                    self.freelancers.push(new Freelancer(item));
                });
                self.itemsCount(data.data.ItemsCount);
            }).fail(function (jqXHR) {
                alert('Failed to fetch Freelancer list. Please try again later.');
                console.error('Failed to fetch Freelancer list:', jqXHR);
            });
        };

        self.prevPage = function () {
            if (self.pageIndex() > 1) {
                self.pageIndex(self.pageIndex() - 1);
                self.getFreelancerList();
            }
        };

        self.nextPage = function () {
            if (self.hasMorePages()) {
                self.pageIndex(self.pageIndex() + 1);
                self.getFreelancerList();
            }
        };

        self.getFreelancerList();
    }

    ko.applyBindings(new AdminViewModel());
});
