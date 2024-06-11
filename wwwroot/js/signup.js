document.addEventListener('DOMContentLoaded', function () {
    // ViewModel for Knockout
    function SignupViewModel() {
        var self = this;

        self.username = ko.observable("").extend({ required: true });
        self.email = ko.observable("").extend({ required: true, email: true });
        self.password = ko.observable("").extend({ required: true, minLength: 8 });
        self.phoneNumber = ko.observable("").extend({ required: true });
        self.skillsets = ko.observable("");
        self.hobby = ko.observable("");

        self.errors = ko.validation.group(self);

        self.submitSignup = function () {
            if (self.errors().length === 0) {
                var signupData = {
                    Username: self.username(),
                    Email: self.email(),
                    Password: self.password(),
                    PhoneNumber: self.phoneNumber(),
                    Skillsets: self.skillsets(),
                    Hobby: self.hobby(),
                    DateJoined: new Date().toISOString() 
                };

                // Perform the signup request
                fetch('/api/Freelancer/signup', {
                    method: 'POST',
                    headers: {
                        'Content-Type': 'application/json'
                    },
                    body: JSON.stringify(signupData)
                })
                .then(response => {
                    if (response.ok) {
                        return response.json();
                    } else {
                        return response.json().then(errorData => {
                            throw new Error(errorData.message || 'Please Double Check Your Username And Email.It Can Not Be The Same');
                        });
                    }
                })
                .then(data => {
                    alert('Congrats! Your profile has been submitted.');
                })
                .catch(error => {
                    console.error('Error:', error);
                    alert(error.message || 'An error occurred. Please try again later.');
                });
            } else {
                self.errors.showAllMessages();
            }
        };
    }

    // Apply bindings
    ko.applyBindings(new SignupViewModel());
});
