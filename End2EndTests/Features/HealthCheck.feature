Feature: HealthCheck
Verifies that the application's health check endpoint is operational.

	Scenario: HealthCheck is successful
		When a GET request is sent to '/health'
		Then the response status code should be 200 OK
		And the response body status should be 'Healthy'
