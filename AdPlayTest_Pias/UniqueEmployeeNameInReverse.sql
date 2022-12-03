
Create proc SpUniqueEmployeeNameInReverse
As
Begin
	Select REVERSE([Name]) from Employee
End