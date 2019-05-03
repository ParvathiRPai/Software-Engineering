#include "stdafx.h"
#include <iostream>

#include "Bar.h"

Bar::Bar()
{
}

Bar::~Bar()
{
	std::cout << "In the Foo destructor";
}
