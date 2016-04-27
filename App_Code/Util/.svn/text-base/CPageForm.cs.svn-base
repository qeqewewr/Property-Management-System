using System;
using System.Collections.Generic;
using System.Web;
using System.Collections;
 

/// <summary>
///CPageForm 的摘要说明
/// </summary>
public class CPageForm
{
	public CPageForm()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}

    
    private int pageno = 1;

	private int nextpage = 1;

	private int prepage = 1;

	private int pagesize = 15;

	private int rowcount = 0;

	private int pagecount = 1;

	private bool useprevious = false;

	private bool usebehind = false;
    private ArrayList pageitems;
	private String[] lipdeep = new String[15];
    public ArrayList getPageitems()
    {
		return this.pageitems;
	}

	public int getPagecount() {
		return this.pagecount;
	}

	public int getPageno() {
		return this.pageno;
	}

	public int getPagesize() {
		return this.pagesize;
	}

	public int getRowcount() {
		return this.rowcount;
	}

	public bool isUsebehind() {
		return this.usebehind;
	}

	public bool isUseprevious() {
		return this.useprevious;
	}

	public int getNextpage() {
		return this.nextpage;
	}

	public int getPrepage() {
		return this.prepage;
	}

    public void setPageitems(ArrayList pageitems)
    {
		this.pageitems = pageitems;
		if (this.pageitems == null) {
            this.pageitems = new ArrayList();
		}
		this.lipdeep = new String[this.pagesize - this.pageitems.Count];
	}

	public void setPagecount(int pagecount) {
		this.pagecount = pagecount;
	}

	public void setPageno(int pageno) {
		this.pageno = pageno;
	}

	public void setPagesize(int pagesize) {
		this.pagesize = pagesize;
	}

	public void setRowcount(int rowcount) {
		this.rowcount = rowcount;
		bool a = this.rowcount % this.pagesize == 0;
		int b = (this.rowcount / this.pagesize == 0) ? 1 : this.rowcount
				/ this.pagesize;
		int c = this.rowcount / this.pagesize + 1;
		this.pagecount = ((a) ? b : c);
		this.useprevious = (this.pageno != 1);
		this.usebehind = (this.pageno != this.pagecount);
		if ((this.pageno >= 1) && (this.pagecount > 1)) {
			this.nextpage = (this.pageno + 1);
		}
		if (this.pageno > 1)
			this.prepage = (this.pageno - 1);
	}

	public void setUsebehind(bool usebehind) {
		this.usebehind = usebehind;
	}

    public void setUseprevious(bool useprevious)
    {
		this.useprevious = useprevious;
	}

	public void setNextpage(int nextpage) {
		this.nextpage = nextpage;
	}

	public void setPrepage(int prepage) {
		this.prepage = prepage;
	}

	public String[] getLipdeep() {
		return this.lipdeep;
	}

	public void setLipdeep(String[] lipdeep) {
		this.lipdeep = lipdeep;
	} 

}