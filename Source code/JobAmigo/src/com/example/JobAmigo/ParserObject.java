package com.example.estore;

public class ParserObject {

	String img;
	String name;
	String desc;
	String title;
	String emp_type;
	String educ;
	String exp;
	String details;
	String loc;
	String pay;
	
	public ParserObject(String img, String name, String desc, String title, String emp_type, String educ, String exp,
			String details, String loc, String pay) {
		this.img = img;
		this.name = name;
		this.desc = desc;
		this.title = title;
		this.emp_type = emp_type;
		this.educ = educ;
		this.exp = exp;
		this.details = details;
		this.loc = loc;
		this.pay = pay;
	}


	
	public String getName() {
		return name;
	}

	public String getDesc() {
		return desc;
	}

	public String getTitle() {
		return title;
	}

	public String getEmpType() {
		return emp_type;
	}

	public String getEduc() {
		return educ;
	}
	
	public String getExp() {
		return exp;
	}
	
	public String getPay() {
		return pay;
	}

	public String getImage() {
		return img;
	}
}
