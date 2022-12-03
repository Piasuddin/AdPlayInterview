
Create proc SpUniqueEmployeeNameInReverse
As
Begin
	Select Distinct REVERSE([Name]) from Employee
End