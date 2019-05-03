#include "stdafx.h"
#include <iostream>
#include "Foo.h"
#include "Bar.h"

Bar* myBar;

Foo::Foo()
{
	myBar = new Bar();
}

Foo::~Foo()
{
	std::cout << "In the Foo destructor";
	delete myBar;
}
