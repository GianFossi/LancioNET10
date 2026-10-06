subroutine FORMATF(bstr)
	use dfcom
	use dfcomty
	integer*4 bstr,Lungh
	Character*(2048) Testo
	Lungh=ConvertBSTRToString(bstr,Testo)
	Testo(2:3)='LP'
	bstr=ConvertStringToBSTR(Testo(1:Lungh))
return
end subroutine
